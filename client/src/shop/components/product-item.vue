<template>
  <div class="card h-100 shadow-sm" v-if="product">
    <img :src="product.pictureUrl" :alt="product.name" class="img-fluid bg-info">
    <div class="card-body d-flex flex-column">
      <router-link :to="`/product/${product.id}`" class="text-decoration-none">
        <h6 class="text-uppercase">
          {{ product.name }}
        </h6>
      </router-link>
      <span class="mb-2">{{ product.price | currency }}</span>

      <div class="btn-group mt-auto">
        <button class="btn btn-outline-secondary fa fa-shopping-cart me-2"></button>
        <button @click="goProdcutDetails(product)" class="btn btn-outline-secondary">View</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
export default {
  props: ["product"],
  methods: {
    ...mapActions(['selectProduct']),
    goProdcutDetails(product) {
        this.$store.dispatch('selectProduct', product)
        this.$router.push(`/product/${product.id}`);
    }
  },
};
</script>