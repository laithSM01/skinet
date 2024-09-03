import Vue from "vue";
import Vuex from "vuex";

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
      console.log(state.selectedProduct)
    }
  },
  mutations: {
    SET_SELECTED_PRODUCT(state, product) {
      state.selectedProduct = product;
    },
  },
  actions: {
    selectProduct({ commit }, product) {
      commit('SET_SELECTED_PRODUCT', product);
    },
  },
  modules: {},
});
