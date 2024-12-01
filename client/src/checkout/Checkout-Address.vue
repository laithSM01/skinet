<template>
  <div class="row mt-3 mb-3">
    <div class="col-md justify-content-center">
      <div class="card card-custom pb-4">
        <div class="card-body mt-0 mx-5">
          <form class="mb-0">
            <div class="row mb-4">
              <div class="col">
                <div data-mdb-input-init class="form-outline">
                  <input
                    type="text"
                    v-model="shipToAddress.firstName"
                    class="form-control input-custom"
                  />
                  <label class="form-label">First name</label>
                </div>
              </div>
              <div class="col">
                <div data-mdb-input-init class="form-outline">
                  <input
                    type="text"
                    v-model="shipToAddress.lastName"
                    class="form-control input-custom"
                  />
                  <label class="form-label">Last name</label>
                </div>
              </div>
            </div>
            <div class="row mb-4">
              <div class="col">
                <div data-mdb-input-init class="form-outline">
                  <input type="text" v-model="shipToAddress.street" class="form-control input-custom" />
                  <label class="form-label">Street</label>
                </div>
              </div>
              <div class="col">
                <div data-mdb-input-init class="form-outline">
                  <input type="text" v-model="shipToAddress.city" class="form-control input-custom" />
                  <label class="form-label">City</label>
                </div>
              </div>
            </div>
            <div class="row mb-4">
              <div class="col">
                <div data-mdb-input-init class="form-outline">
                  <input type="text" v-model="shipToAddress.state" class="form-control input-custom" />
                  <label class="form-label">State</label>
                </div>
              </div>
              <div class="col">
                <div data-mdb-input-init class="form-outline">
                  <input
                    type="email"
                    v-model="shipToAddress.zipcode"
                    class="form-control input-custom"
                  />
                  <label class="form-label">Zip Code</label>
                </div>
              </div>
            </div>
          </form>
        </div>
        <div class="float-end ">
            <button @click="updateAddress" class="btn btn-success m-1">Save Address</button>
              <!-- Button trigger modal -->
          </div>
    <successModal  :showModal="showModal" @update:showModal="showModal = $event" :successMessage="successMessage"/>
      </div>
    </div>
  </div>
</template>
<script>
import AccountService from "@/account/service/account.service";
import successModal from "@/shared/modals/success-modal.vue";
import { mapState } from 'vuex';
export default {
  data() {
    return {
      showModal: false,
      successMessage: 'Address has been saved!'
    };
  },
  components: {successModal: successModal},
  created() {
    this.getAddressFormValues();
  },
  computed: {
    ...mapState(['shipToAddress'])
  },
  methods: {
    getAddressFormValues() {
      AccountService.getUserAddress().then((response) => {
        if (response) {
          this.$store.dispatch('setAddress', response.data)
        }
      });
    },
    updateAddress() {
      AccountService.updateUserAddress(this.shipToAddress).then(res => {
        if (res.status) {
          this.showModal = true;
          }
      })
    },
  },
};
</script>

<style scoped>
.gradient-custom {
  background: -webkit-linear-gradient(left, #3931af, #00c6ff);
}

.card-custom {
  border-bottom-left-radius: 10% 50%;
  border-top-left-radius: 10% 50%;
  background-color: #f8f9fa;
}

.input-custom {
  background-color: white;
}

.white-text {
  color: hsl(52, 0%, 98%);
  font-weight: 100;
  font-size: 14px;
}

.back-button {
  background-color: hsl(52, 0%, 98%);
  font-weight: 700;
  color: black;
  margin-top: 50px;
}
</style>
