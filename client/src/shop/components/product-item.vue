<template>
  <div class="image card h-100 shadow-sm" v-if="product">
    <img :src="product.pictureUrl" :alt="product.name" class="img-fluid bg-info">
    <div class="card-body d-flex flex-column">
        <h6 class="text-uppercase">
          {{ product.name }}
        </h6>
      <span class="mb-2">{{ product.price | currency }}</span>

      <div class="d-flex align-items-center justify-content-center hover-overlay">
        <button @click="addTobasket()" class="btn btn-outline-secondary bi bi-shopping-cart me-2"></button>
        <button @click="goProdcutDetails(product)" class="btn btn-outline-secondary">View</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from 'vuex';
import BasketService from '@/basket/service/basket.service';
export default {
  data() {
    return null
  },
  props: ["product"],
  computed: {
    ...mapState(['selectedProduct', 'basket']),
    mapProductItemToBasketItem(item) {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      quantity: 0,
      pictureUrl: item.pictureUrl,
      brand: item.productBrand,
      type: item.productType
    };
  },
  },
  methods: {
    ...mapActions(['selectProduct', 'addItemToBasket']),
    goProdcutDetails(product) {
        this.$store.dispatch('selectProduct', product)
        .then(() => {
          this.$router.push(`/product/${product.id}`);
        })
    },
   
    addTobasket() {
      BasketService.addItemToBasket(this.product)
    }
  },
};
</script>
<style scoped>
.btn {
    width: 30%;
    height: 40px;
}

.image :hover {
    opacity: 1;
    & button {
        transform: none;
        opacity: 1;
    }
}

.hover-overlay {
    position: absolute;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    background: rgba(255,255,255,0.5);
    opacity: 0;
    transition: all 0.5s;

    & button {
        z-index: 1000;
        transition: all 0.5s;
    }

    & button:first-of-type {
        transform: translateX(-20px);
    }

    & button:last-of-type {
        transform: translateX(20px);
    }
}
</style>