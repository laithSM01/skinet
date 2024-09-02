<template>
         <header>
            <span v-if="totalCount && totalCount > 0">Showing <strong>
            {{ (shopParams.pageNumber-1) * shopParams.pageSize + 1}} - 
            {{ shopParams.pageNumber * shopParams.pageSize
              > totalCount ? totalCount : shopParams.pageNumber*shopParams.pageSize }}
            </strong> of <strong>{{ totalCount }}</strong> items</span>
            <span v-if="totalCount === 0">There are no results</span>
          </header>
</template>

<script>
export default {
    props:["shopParams", "totalCount"]
}
</script>