<template>
    <div class="mt-4">
      <div class="row">
        <div class="col-6 form-group" v-for="method in deliveryMethods" :key="method.id">
          <input type="radio" :id="method.shortName" name="deliveryMethod" v-model="method.value" :value="method" @click="selectShippingPrice(method.price); getDeliveryMethodId(method.id)">
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
    };
  },
    created(){
        this.getDeliveryMethods();
    },
    methods:{
        getDeliveryMethods() {
            CheckOutService.getDeliveryMethods().then(response => {
                this.deliveryMethods = response;
            },error => {
                console.log(error);
            })
        },
        selectShippingPrice(methodPrice) {
          this.$store.dispatch('setBasketPrice',methodPrice)
        },
        getDeliveryMethodId(methodId) {
         this.$store.dispatch('setDeilveryMethodId', methodId)
        }
    }
}
</script>