<template>
         <b-pagination
      v-model="shopParams.pageNumber"
      :total-rows="totalCount"
      :per-page="shopParams.pageSize"
      @change="onPageChange"
      first-number
      last-number
    />
</template>

<script>
export default {
    props: ["shopParams", "totalCount"],
  methods: {
    onPageChange(event) {
      this.shopParams.pageNumber = event;
    this.$emit('changePage', this.shopParams.pageNumber)
    },
  }
}
</script>