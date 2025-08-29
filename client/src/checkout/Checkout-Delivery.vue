<template>
  <div class="mt-4">
    <div class="row">
      <div class="col-6 form-group" v-for="method in deliveryMethods" :key="method.id">
        <input
          type="radio"
          :id="method.shortName"
          name="deliveryMethod"
          v-model="selectedDeliveryMethod"
          :value="method.id"
          @click="selectShippingPrice(method.price, method.id)"
        >
        <label :for="method.shortName">{{ method.shortName }} - {{ method.description }} - JOD {{ method.price }}</label>
      </div>
    </div>
  </div>
</template>

<script>
import CheckOutService from './service/checkout.service';
export default {
  data() {
    return {
      deliveryMethods: [],
      selectedDeliveryMethod: null,
    };
  },
  created() {
    this.getDeliveryMethods();
    
    // Retrieve the selected delivery method from local storage
    this.selectedDeliveryMethod = localStorage.getItem('selectedDeliveryMethod');
  },
  methods: {
    getDeliveryMethods() {
      CheckOutService.getDeliveryMethods().then(response => {
        this.deliveryMethods = response;
      }, error => {
        console.log(error);
      });
    },
    selectShippingPrice(methodPrice, methodId) {
      // Save the selected delivery method to local storage
      localStorage.setItem('selectedDeliveryMethod', methodId);
      
      this.selectedDeliveryMethod = methodId;
      this.$store.dispatch('setBasketPrice', methodPrice);
    }
  }
};
</script>