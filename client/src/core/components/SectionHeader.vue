<template>
  <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb" class="bread-crumb ">
    <b-breadcrumb>
      <b-breadcrumb-item
        v-for="(crumb, index) in getBreadcrumbHierarchy(breadcrumbs)"
        :key="index"
        :href="crumb.to.path"
        :active="index === breadcrumbs.length - 1"
      >
        {{ crumb.text === 'product-details' ? selectedProduct?.name : crumb.text }}
      </b-breadcrumb-item>
    </b-breadcrumb>
  </nav>
</template>

<script>
import { mapState } from 'vuex';

export default {
  computed: {
    ...mapState(['selectedProduct']),
    breadcrumbs() {
      return this.$route.meta.breadcrumb;
    },
  },
  methods: {
    getBreadcrumbHierarchy(crumbs) {
      const hierarchy = [];
      const findParent = (parentName) => {
        const parent = crumbs.find((c) => c.text === parentName);
        if (parent) {
          hierarchy.unshift(parent);
          if (parent.parent) {
            findParent(parent.parent);
          }
        }
      };

      findParent(crumbs[crumbs.length - 1].text);
      return hierarchy;
    },
  },
};
</script>

<style>
.bread-crumb {
  background-color: #f5f5f5;
}
.box {
  box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
}
</style>