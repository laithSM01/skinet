<template>
    <div class="row">
    <div class="col-8">
    <appStepper/>
    </div>
    <div class="col-4">
    <appOrderTotals/>
    </div>
    </div>
</template>

<script>
import OrderTotals from "@/shared/components/Order-totals.vue";
import Stepper from "@/shared/components/Stepper.vue";
export default {
 components: {appOrderTotals: OrderTotals,appStepper: Stepper },

}
</script>