import Vue from "vue";
import Vuex from "vuex";
import ShopService from "@/shop/service/shop.service";
import BasketService from "@/basket/service/basket.service";

Vue.use(Vuex);

export default new Vuex.Store({
  state() {
    return {
      selectedProduct: null, // Initially no product selected
      basket: null,
      basketTotals: null
    };
  },
  getters: {
    fetchProduct: state => {
      state.selectedProduct
    },
  },
  mutations: {
    SET_SELECTED_PRODUCT(state, product) {
      state.selectedProduct = product;
    },
    addToBasket(state, product) {
      console.log("product in mutation", product)
      state.basket.push(product);
    },
    updateItemQuantity(state, { id, quantity }) {
      const itemIndex = state.basket.findIndex(item => item.id === id);
      if (itemIndex == -1) {
        console.log("hi")
        state.basket[itemIndex].quantity += quantity;
      }
    },
    clearBasket(state) {
      state.basket = [];
    }
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
    addItemToBasket({ commit, state }, { item, quantity = 1 }) {
      const existingItemIndex = state.basket.findIndex(i => i.id === item.id);

      if (existingItemIndex !== -1) {
        commit('updateItemQuantity', { id: item.id, quantity });
      } else {
        console.log("addToBasket")
        commit('addToBasket', { ...item, quantity });
      }
    },
    clearBasket({ commit }) {
      commit('clearBasket');
    }
  },
  modules: {},
});
