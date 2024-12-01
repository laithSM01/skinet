<template>
  <div>
    <p>checkout-payment works!</p>
      <button class="btn btn-primary" @click="submitOrder">
        Submit order
      </button>
    <div class="d-flex justify-content-between flex-row mb-5">
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex';
import CheckOutService from './service/checkout.service';
export default {
  data() {
    return {
      orderPayload: {
        basketId: '',
        deliveryMethodId: null,
        shipToAddress: {
          firstName: '',
          lastName: '',
          street: '',
          city: '',
          state: '',
          country: '',
          zipcode: ''
        }
      },
      successMessage: 'Order created successfully !'
    };
  },
  computed: {
    ...mapState(['checkoutForm', 'deliveryMethodId', 'basket', 'shipToAddress'])
  },
  methods: {
    backToReview() {
      // Handle navigation back to review if needed
    },
    submitOrder() {
      const basket = this.basket;
      if (!basket) return;
      const orderToCreate = this.getOrderToCreate(basket);
      if (!orderToCreate) return;
      CheckOutService.createOrder(orderToCreate).then(order => {
        localStorage.removeItem('basket_id');
        this.$router.push("/checkout/success");
      });
    },
    getOrderToCreate(basket) {
      var { deliveryMethodId, shipToAddress } = this.orderPayload;
      deliveryMethodId = this.deliveryMethodId
      shipToAddress = this.shipToAddress
      if (!deliveryMethodId || !shipToAddress) return;
      return {
        basketId: basket.id,
        deliveryMethodId: deliveryMethodId,
        shipToAddress: shipToAddress
      };
    }
  },
};
</script>