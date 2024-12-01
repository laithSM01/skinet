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
import axios from 'axios';

import 'bootstrap/dist/css/bootstrap.min.css';

// Import Bootstrap Bundle (which includes the modal functionality)
import 'bootstrap/dist/js/bootstrap.bundle.min.js';


Vue.config.productionTip = false;

// Install BootstrapVue
Vue.use(BootstrapVue)


Vue.filter('currency', (value) => {
  return  `JOD ${value.toLocaleString()}`;
});

axios.interceptors.request.use(config => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
}, error => {
  return Promise.reject(error);
});

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
