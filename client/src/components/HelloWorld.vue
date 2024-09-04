<template>
  <div>
  <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="../assets/images/hero1.jpg" alt="slide" style="display: block; width: 100%;">
    </div>
    <div class="carousel-item">
      <img src="../assets/images/hero2.jpg" alt="slide" style="display: block; width: 100%;">
    </div>
    <div class="carousel-item">
      <img src="@/assets/images/hero3.jpg" alt="slide" style="display: block; width: 100%;">
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
<section class="featured py-5"> 
  <h2 class="text-center mb-4">Welcome to the Shop!</h2>
  <div class="row">
    </div>
</section>
</div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.featured {
    height: 250px;
}

img {
    object-fit: cover;
    height: 600px;
    width: 100%;
}
</style>
