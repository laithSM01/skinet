<template>
  <div class="container pb-5 mb-sm-4">
    <!-- Details-->
    <div class="row mb-3">
      <div class="col-sm-4 mb-2">
        <div class="bg-secondary p-4 text-dark text-center">
          <span class="font-weight-semibold mr-2">Shipped via:</span>UPS Ground
        </div>
      </div>
      <div class="col-sm-4 mb-2">
        <div class="bg-secondary p-4 text-dark text-center">
          <span class="font-weight-semibold mr-2">Status:</span>Quality check
        </div>
      </div>
      <div class="col-sm-4 mb-2">
        <div class="bg-secondary p-4 text-dark text-center">
          <span class="font-weight-semibold mr-2">Expected date:</span>June 17, 2019
        </div>
      </div>
    </div>
    <!-- Progress-->
    <div class="steps">
      <div class="steps-header">
        <div class="progress">
          <div
            class="progress-bar"
            role="progressbar"
            :style="{ width: e6 * 25 + '%' }"
            :aria-valuenow="e6 * 25"
            :aria-valuemin="0"
            aria-valuemax="100"
          ></div>
        </div>
      </div>
      <div class="steps-body">
        <div class="step" @click="e6 = 1" :class="{ 'step-completed': e6 > 1 }">
          <span class="step-indicator bi-check-lg"></span
          ><span class="step-icon bi-geo-alt"></span>Address
        </div>
        <div class="step" @click="e6 = 2" :class="{ 'step-completed': e6 > 2 }">
          <span class="step-indicator bi-check-lg"></span
          ><span class="step-icon bi-truck"></span>Delivery
        </div>
        <div class="step" @click="e6 = 3" :class="{ 'step-completed': e6 > 3 }">
          <span class="step-indicator bi-check-lg"></span
          ><span class="step-icon bi-layout-text-window-reverse"></span>Review
        </div>
        <div class="step" @click="e6 = 4" :class="{ 'step-completed': e6 > 4 }">
          <span class="step-indicator bi-check-lg"></span
          ><span class="step-icon bi-credit-card"></span>Payment
        </div>
      </div>
    </div>
    <component :is="checkoutComponent"></component>
        <!-- forward-back buttons -->
        <div class="float-start ">
            <button
            v-if="!isFirstStep"
             @click="prevStep" data-mdb-button-init data-mdb-ripple-init class="btn btn-primary btn-rounded"
              style="background-color: #0062CC ;">previous</button>
          <router-link
      v-else
      to="/basket"
      class="btn btn-primary btn-rounded"
      style="background-color: #0062CC;"
    >
      Back to Basket
    </router-link>
          </div>
          <div class="float-end ">
            <button 
            v-if="!isLastStep"
            @click="nextStep" :disabled="e6 === 4" data-mdb-button-init data-mdb-ripple-init class="btn btn-primary btn-rounded"
              style="background-color: #0062CC ;">next</button>
          </div>
  </div>
</template>

<script>
import CheckoutAddress from "@/checkout/Checkout-Address.vue";
import CheckoutDelivery from "@/checkout/Checkout-Delivery.vue";
import CheckoutPayment from "@/checkout/Checkout-Payment.vue";
import CheckoutReview from "@/checkout/Checkout-Review.vue";
export default {
  data() {
    return {
      e6: 1,
    };
  },
  computed: {
    checkoutComponent() {
      switch (this.e6) {
        case 1:
          return CheckoutAddress;
        case 2:
          return CheckoutDelivery;
        case 3:
            return CheckoutReview;
        case 4: 
            return CheckoutPayment
        default:
          return "CheckoutAddress"; // Default to Address component
      }
    },
    isFirstStep() {
      return this.e6 === 1;
    },
    isLastStep() {
      return this.e6 === 4;
    },
  },
  methods: {
    nextStep() {
      if (this.e6 < 4) {
        this.e6++;
      }
    },
    prevStep() {
      if (this.e6 > 1) {
        this.e6--;
      }
    }
  },
  created() {
    const basketId = localStorage.getItem("basket_id");
    this.$store.dispatch("getBasket", basketId);
  },
};
</script>

<style scoped>
body {
  margin-top: 20px;
}

.steps {
  border: 1px solid #e7e7e7;
}

.steps-header {
  padding: 0.375rem;
  border-bottom: 1px solid #e7e7e7;
}

.steps-header .progress {
  height: 0.25rem;
}

.steps-body {
  display: table;
  table-layout: fixed;
  width: 100%;
}

.step {
  display: table-cell;
  position: relative;
  padding: 1rem 0.75rem;
  -webkit-transition: all 0.25s ease-in-out;
  transition: all 0.25s ease-in-out;
  border-right: 1px dashed #dfdfdf;
  color: rgba(0, 0, 0, 0.65);
  font-weight: 600;
  text-align: center;
  text-decoration: none;
}

.step:last-child {
  border-right: 0;
}

.step-indicator {
  display: block;
  position: absolute;
  top: 0.75rem;
  left: 0.75rem;
  width: 1.5rem;
  height: 1.5rem;
  border: 1px solid #e7e7e7;
  border-radius: 50%;
  background-color: #fff;
  font-size: 0.875rem;
  line-height: 1.375rem;
}

.has-indicator {
  padding-right: 1.5rem;
  padding-left: 2.375rem;
}

.has-indicator .step-indicator {
  top: 50%;
  margin-top: -0.75rem;
}

.step-icon {
  display: block;
  width: 1.5rem;
  height: 1.5rem;
  margin: 0 auto;
  margin-bottom: 0.75rem;
  -webkit-transition: all 0.25s ease-in-out;
  transition: all 0.25s ease-in-out;
  color: #888;
}

.step:hover {
  color: rgba(0, 0, 0, 0.9);
  text-decoration: none;
}

.step:hover .step-indicator {
  -webkit-transition: all 0.25s ease-in-out;
  transition: all 0.25s ease-in-out;
  border-color: transparent;
  background-color: #f4f4f4;
}

.step:hover .step-icon {
  color: rgba(0, 0, 0, 0.9);
}

.step-active,
.step-active:hover {
  color: rgba(0, 0, 0, 0.9);
  pointer-events: none;
  cursor: default;
}

.step-active .step-indicator,
.step-active:hover .step-indicator {
  border-color: transparent;
  background-color: #5c77fc;
  color: #fff;
}

.step-active .step-icon,
.step-active:hover .step-icon {
  color: #5c77fc;
}

.step-completed .step-indicator,
.step-completed:hover .step-indicator {
  border-color: transparent;
  background-color: rgba(51, 203, 129, 0.12);
  color: #33cb81;
  line-height: 1.25rem;
}

.step-completed .step-indicator .feather,
.step-completed:hover .step-indicator .feather {
  width: 0.875rem;
  height: 0.875rem;
}

@media (max-width: 575.98px) {
  .steps-header {
    display: none;
  }
  .steps-body,
  .step {
    display: block;
  }
  .step {
    border-right: 0;
    border-bottom: 1px dashed #e7e7e7;
  }
  .step:last-child {
    border-bottom: 0;
  }
  .has-indicator {
    padding: 1rem 0.75rem;
  }
  .has-indicator .step-indicator {
    display: inline-block;
    position: static;
    margin: 0;
    margin-right: 0.75rem;
  }
}

.bg-secondary {
  background-color: #f7f7f7 !important;
}
</style>
