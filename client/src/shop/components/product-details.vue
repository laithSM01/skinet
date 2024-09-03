<template>
  <div class="row" v-if="selectedProduct">
    <div class="col-6">
        <img :src="selectedProduct.pictureUrl" :alt="selectedProduct.name" class="w-50">
    </div>
    <div class="col-6 mt-5">
        <h2>{{selectedProduct.name}}</h2>
        <p>{{selectedProduct.price | currency}}</p>
        <div class="d-flex justify-content-start align-items-center">
            <i class="fa fa-minus-circle text-warning me-2" style="cursor: pointer; font-size: 2em;"></i>
            <span class="font-weight-bold" style="font-size: 1.5em;">2</span>
            <i class="fa fa-plus-circle text-warning ms-2" style="cursor: pointer; font-size: 2em;"></i>
            <button class="btn btn-outline-secondary ms-4">Add to cart</button>
        </div>
        <div class="row mt-4">
            <h4>Description</h4>
            <p>{{selectedProduct.description}}</p>
        </div>
    </div>
</div>
</template>

<script>
import { mapState, mapActions } from 'vuex';
export default {
  computed: {
    ...mapState(['selectedProduct']),
  },
  methods: {
     fetchProduct(productId) {
  try {
    const response =  fetch(`/product/${productId}`);
    const product =  response.json();
    console.log(product, "fetching")
    this.selectedProduct = product; // Store in local state
    console.log("still fetching",this.selectedProduct )
  } catch (error) {
    console.error("Error fetching product:", error);
  }
},
    },
    created() {
        const productId = this.$route.params.id;
        this.fetchProduct(productId);
    }
  };
</script>