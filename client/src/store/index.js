import Vue from "vue";
import Vuex from "vuex";
import ShopService from "@/shop/service/shop.service";

Vue.use(Vuex);

export default new Vuex.Store({
  state() {
    return {
      selectedProduct: null, // Initially no product selected
    };
  },
  getters: {
    fetchProduct: state => {
      state.selectedProduct
    }
  },
  mutations: {
    SET_SELECTED_PRODUCT(state, product) {
      state.selectedProduct = product;
    },
  },
  actions: {
    selectProduct({ commit }, product) {
      ShopService.getProduct(product.id)
      .then(res => {
        res.data.id = product.id
        commit('SET_SELECTED_PRODUCT', res.data);
        localStorage.setItem('selectedProduct', JSON.stringify(res));
      })
    },
  },
  modules: {},
});
