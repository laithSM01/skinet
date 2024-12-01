<template>
    <div>
        <div class="success-page">
    <div class="container">
      <h1>Success!</h1>
      <p>Your action was completed successfully.</p>
      <!-- <button @click="goBack">Go Back</button> -->
    </div>
  </div>
    <successModal  :showModal="showModal" @update:showModal="showModal = $event" :successMessage="successMessage"/>
    </div>
</template>

<script>
import successModal from "@/shared/modals/success-modal.vue";
export default {
    data() {
    return {
      showModal: true,
      successMessage: 'Order created successfully !'
    };
  },
  components: {successModal: successModal},
}
</script>

<style scoped>
.success-page {
  text-align: center;
  margin-top: 50px;
}

.container {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
  background-color: #f4f8f9;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

h1 {
  color: #28a745;
}
button {
  padding: 10px 20px;
  background-color: #28a745;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #218838;
}
</style>