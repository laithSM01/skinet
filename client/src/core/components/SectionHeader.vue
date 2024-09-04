<template>
  <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb" class="bread-crumb ">
    <b-breadcrumb>
      <b-breadcrumb-item
        v-for="(crumb, index) in getBreadcrumbHierarchy(breadcrumbs)"
        :key="index"
        :href="crumb.to.path"
        :active="index === breadcrumbs.length - 1"
      >
        {{ crumb.text }}
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

      // Check if the path has "shop/" and something after it
      const lastCrumbText = crumbs[crumbs.length - 1].text;
      const pathAfterShop = lastCrumbText.split('/').slice(-1)[0]; // Get the last part of the path

      if (pathAfterShop !== "shop" && pathAfterShop !== "home") {
        // If there's something after "shop/", update the breadcrumb
        // Use the selectedProduct from the store
        if (this.selectedProduct?.name) {
          crumbs[crumbs.length - 1].text = this.selectedProduct?.name;
        }
      }

      findParent(crumbs[crumbs.length - 1].text);
      return hierarchy;
    },
  },
  created() {
    // You might need to check if selectedProduct is available here
    // if you are navigating to the product details page before the product is loaded
    // You can use a watcher for that
  }
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