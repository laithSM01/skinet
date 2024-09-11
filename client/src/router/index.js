import Vue from "vue";
import VueRouter from "vue-router";
import HomeView from "../views/HomeView.vue";
import ShopView from "@/views/ShopView.vue";
import BasketView from "@/views/BasketView.vue";
import productDetails from "@/shop/components/product-details.vue";

Vue.use(VueRouter);

// router.vue
const routes = [
  {
    name: "home",
    meta: {
      title: "home",
      breadcrumb: [
        {
          text: "home",
          disabled: false,
          active: false,
          to: { name: "home" },
          parent: null, // No parent for the home route
        },
      ],
    },
    path: "/",
    component: HomeView,
  },
  {
    name: "shop",
    meta: {
      title: "shop",
      breadcrumb: [
        {
          text: "home",
          disabled: false,
          active: false,
          to: { name: "home" },
          parent: null, // No parent for the home route
        },
        {
          text: "shop",
          disabled: false,
          active: false,
          to: { name: "shop" },
          parent: "home", // Parent is the home route
        },
      ],
    },
    path: "/shop",
    component: ShopView,
  },
  {
    name: "product-details",
    meta: {
      title: "product-details",
      breadcrumb: [
        {
          text: "home",
          disabled: false,
          active: false,
          to: { name: "home" },
          parent: null, // No parent for the home route
        },
        {
          text: "shop",
          disabled: false,
          active: false,
          to: { name: "shop" },
          parent: "home", // Parent is the home route
        },
        {
          text: "product-details",
          disabled: false,
          active: false,
          to: { name: "product-details" },
          parent: "shop", // Parent is the shop route
        },
      ],
      productName: null,
    },
    path: "/product/:id",
    component: productDetails,
  },
  {
    name: "basket",
    meta: {
      title: "basket",
      breadcrumb: [
        {
          text: "home",
          disabled: false,
          active: false,
          to: { name: "home" },
          parent: null, // No parent for the home route
        },
        {
          text: "basket",
          disabled: false,
          active: false,
          to: { name: "basket" },
          parent: "home", // Parent is the home route
        },
      ],
    },
    path: "/basket",
    component: BasketView,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
