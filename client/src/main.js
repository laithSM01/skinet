import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap";
import BootstrapVue from 'bootstrap-vue'
// Import Bootstrap and BootstrapVue CSS files (if using CSS)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'bootstrap-icons/font/bootstrap-icons.css'

Vue.config.productionTip = false;

// Install BootstrapVue
Vue.use(BootstrapVue)


Vue.filter('currency', (value) => {
  return  `JOD ${value.toLocaleString()}`;
});

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
