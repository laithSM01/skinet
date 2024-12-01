<template>
  <div class="container mt-5">
    <div v-if="!basket.items.length">
      <p>There are no items in your basket</p>
    </div>

    <div class="container" v-if="basket.items.length">
      <div class="row">
      <app-basket-summary :basket="basket" :isBasket="true"></app-basket-summary>
      </div>

      <div class="row">
                <div class="col-6 offset-6">
                    <app-order-totals></app-order-totals>
                    <div class="d-grid">
                        <router-link to="/checkout" class="btn btn-outline-primary py-2">
                            Proceed to checkout
                        </router-link>
                    </div>
                </div>
            </div>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
import OrderTotals from "@/shared/components/Order-totals.vue";
import basketSummary from "@/shared/components/basket-summary.vue";
export default {
  data() {
    return {};
  },
  components: {appOrderTotals: OrderTotals, appBasketSummary: basketSummary},

  computed: {
    ...mapState(["basket"]),
  },
  created() {
    const basketId = localStorage.getItem('basket_id')
    this.$store.dispatch('getBasket', basketId)
  }
};
</script>
