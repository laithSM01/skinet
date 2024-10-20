import Vue from "vue";
import Vuex from "vuex";
import ShopService from "@/shop/service/shop.service";
import BasketService from "@/basket/service/basket.service";
import accountService from '@/account/service/account.service'
import { v4 as uuidv4 } from 'uuid';
import { error } from "jquery";

Vue.use(Vuex);
const currentUserSource = Vue.observable({ user: null });

export default new Vuex.Store({
  state() {
    return {
      selectedProduct: null, // Initially no product selected
      basket: { items: [] },
      basketTotals: null,
      currentUser: currentUserSource.user,
      errorMessages: []
    };
  },
  getters: {
    fetchProduct: state => {
      state.selectedProduct
    },
    calculateTotals: state => {
      state.basket.id = localStorage.getItem('basket_id')
      if(!state.basket) return
      const shipping = 0;
      const subtotal = state.basket.items.reduce((acc, item) => acc + item.price * item.quantity, 0);
      const total = subtotal + shipping;
      return { shipping, total, subtotal };
    }
  },
  mutations: {
    SET_SELECTED_PRODUCT(state, product) {
      state.selectedProduct = product;
    },
       ADD_TO_BASKET(state, product) {
      const existingItemIndex = state.basket.items.findIndex(i => i.id === product.id);
      if (existingItemIndex !== -1) {
        state.basket.items[existingItemIndex].quantity++;
      } else {
        product.quantity = 1;
        state.basket.items.push(product);
      }

      if(!localStorage.getItem('basket_id')){
          state.basket.id = uuidv4(); // Generate UUID if ID is missing
          localStorage.setItem('basket_id', state.basket.id);
      } else {
       state.basket.id =  localStorage.getItem('basket_id')
      }
    },
     REMOVE_ITEM_FROM_BASKET(state, {id, quantity = 1}) {
       if (!state.basket) return;
       const itemIndex = state.basket.items.findIndex(i => i.id === id);
      if (itemIndex !== -1) {
        state.basket.items[itemIndex].quantity -= quantity;
        if (state.basket.items[itemIndex].quantity <= 0) {
          state.basket.items.splice(itemIndex, 1);
        }
      }
    },
    GET_BASKET(state, basket) {
      state.basket = basket;
    },
    SET_USER(state, user) {
      state.currentUser = user;
    },
    SET_CURRENT_USER(state, user) {
      state.currentUser = user;
    },
    SET_ERRORS(state, errors) {
      state.errorMessages = errors;
    }

  },
  actions: {
    async selectProduct({ commit }, product) {
     await ShopService.getProduct(product.id)
      .then(res => {
        res.data.id = product.id
        commit('SET_SELECTED_PRODUCT', res.data);
        localStorage.setItem('selectedProduct', JSON.stringify(res));
      })
    },
     async addItemToBasket({commit, state} ,item) {
      try {
      commit('ADD_TO_BASKET', item)
         await BasketService.setBasket(state.basket);
      } catch (error) {
        console.error(error);
      }
    },
    async removeItemFromBasket({commit, state}, {id, quantity}) {
      commit('REMOVE_ITEM_FROM_BASKET', {id, quantity})
      if (state.basket.items.length > 0) {
       await BasketService.setBasket(state.basket);
      } else {
        localStorage.removeItem('basket_id');
       BasketService.deleteBasket(state.basket);
      }
    },
    async decrementQuantity({commit, state}, id) {
      commit('REMOVE_ITEM_FROM_BASKET', {id})
       await BasketService.setBasket(state.basket);
    },
    async getBasket({commit}, id) {
      await BasketService.getBasket(id)
      .then(res => {
        commit('GET_BASKET', res)
      })
    },
    async login({ commit }, user) {
      await accountService.login(user).then(res => {
        commit('SET_USER', res);
    }, error => {
        console.log(error)
    })
    },
    async getCurrentUser({commit}) {
      await accountService.getUser(). then(res => {
        commit('SET_USER', res);
      //  console.log('from store: ',res)
      }, error => {
        console.log(error)
      });
    },
    async signup({ commit }, user) {
      await accountService.register(user).then(res => {
        // commit('SET_USER', res);
      }, error => {
        commit('SET_ERRORS', error.response.data.errors);
    })
    },
  },
  modules: {},
});
