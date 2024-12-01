<template>
  <div class="table-responsive">
    <table class="table">
      <thead class="bg-light text-uppercase">
        <tr>
          <th><div class="py-2">Product</div></th>
          <th><div class="py-2">Price</div></th>
          <th><div class="py-2">Quantity</div></th>
          <th><div class="py-2">Total</div></th>
          <th><div v-if="isBasket" class="py-2">Remove</div></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in basket.items">
          <th>
            <div class="p-2 d-inline-block">
              <img
                :src="item.pictureUrl"
                :alt="item.productName"
                class="img-fluid"
                style="max-height: 50px"
              />
              <div class="ms-3 d-inline-block align-middle">
                <span class="text-muted fst-italic"> Type: {{ item.type }} </span>
              </div>
            </div>
          </th>
          <td class="align-middle">
            <strong>{{ item.price | currency }}</strong>
          </td>
          <td class="align-middle">
            <div class="align-items-center">
              <i
                class="bi bi-dash-circle text-warning me-2"
                style="cursor: pointer; font-size: 2em"
                @click="removeItem(item.id, 1)"
                v-if="isBasket"
              ></i>
              <strong style="font-size: 1.5em">{{ item.quantity }}</strong>
              <i
                class="bi bi-plus-circle text-warning mx-2"
                style="cursor: pointer; font-size: 2em"
                @click="incrementQuantity(item)"
                v-if="isBasket"
              ></i>
            </div>
          </td>
          <td class="align-middle">
            <strong>{{ (item.price * item.quantity) | currency }}</strong>
          </td>
          <td class="align-middle">
            <a v-if="isBasket" class="text-danger">
              <i
                @click="
                  $store.dispatch('removeItemFromBasket', {
                    id: item.id,
                    quantity: item.quantity,
                  })
                "
                class="bi bi-trash"
                style="font-size: 2em; cursor: pointer"
              ></i>
            </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  props: {
    basket: {
      type: Object,
      required: true,
    },
    isBasket: {
        type: Boolean
    }
},
    methods: {
      incrementQuantity(item) {
        this.$store.dispatch("addItemToBasket", item);
      },
      removeItem(id) {
        this.$store.dispatch("decrementQuantity", id);
      },
    },
};
</script>
