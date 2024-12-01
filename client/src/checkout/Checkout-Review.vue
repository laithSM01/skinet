<template>
    <app-basket-summary :basket="basket" :isbasket="false"></app-basket-summary>
</template>

<script>
import basketSummary from '@/shared/components/basket-summary.vue';
import { mapState } from 'vuex';
export default {
    components: {appBasketSummary : basketSummary},
    computed: {
    ...mapState(["basket"]),
  },
}
</script>