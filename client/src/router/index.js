import Vue from "vue";
import VueRouter from "vue-router";
import HomeView from "../views/HomeView.vue";
import ShopView from "@/views/ShopView.vue";
import BasketView from "@/views/BasketView.vue";
import CheckoutView from "@/views/CheckoutView.vue";
import productDetails from "@/shop/components/product-details.vue";
import LoginView from "@/views/LoginView.vue";
import RegisterView from "@/views/RegisterView.vue";

Vue.use(VueRouter);
export function authGuard(to, from, next) {
  const token = localStorage.getItem('token');
  
  if (token) {
    // Optionally, you can add additional checks like token expiration here
    next(); // Allow navigation to the requested route
  } else {
    // Redirect to login page if no token is found
    next({ name: 'login' }); // Assuming 'login' is the name of your login route
  }
}

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
  {
    name: "checkout",
    meta: {
      title: "checkout",
      breadcrumb: [
        {
          text: "home",
          disabled: false,
          active: false,
          to: { name: "home" },
          parent: null, // No parent for the home route
        },
        {
          text: "checkout",
          disabled: false,
          active: false,
          to: { name: "checkout" },
          parent: "home", // Parent is the home route
        },
      ],
    },
    path: "/checkout",
    component: CheckoutView,
    beforeEnter: authGuard // Apply auth guard to this route
  },
  {
    name: "login",
    meta: {
      title: "login",
      breadcrumb: [
        {
          text: "",
          disabled: false,
          active: false,
          to: { name: "home" },
          parent: null, // No parent for the home route
        },
        {
          text: "login",
          disabled: false,
          active: false,
          to: { name: "login" },
          parent: "home", // Parent is the home route
        },
      ],
    },
    path: "/login",
    component: LoginView,
  },
  {
    name: "register",
    meta: {
      title: "register",
      breadcrumb: [
        {
          text: "",
          disabled: false,
          active: false,
          to: { name: "home" },
          parent: null, // No parent for the home route
        },
        {
          text: "register",
          disabled: false,
          active: false,
          to: { name: "register" },
          parent: "home", // Parent is the home route
        },
      ],
    },
    path: "/register",
    component: RegisterView,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
