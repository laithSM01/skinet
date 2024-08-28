<template>
  <div class="about">
    <h1>This is an about page</h1>
    <ul>
      <li v-for="product in products.data" :key="product.id">{{ product.name }}</li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios';
export default {

  data() {
    return {
       products:[]
    };
  },

  created() {
    axios.get('http://localhost:5212/api/Products?Sort=priceDesc&Search=blue')
    .then((result: ) => {
      console.log(result);
      this.products = result.data;
      console.log(this.products.data[0].name)
      console.log(this.products.data.length)
    }).catch((err) => {
      console.log(err)
    });
  }
}
</script>
