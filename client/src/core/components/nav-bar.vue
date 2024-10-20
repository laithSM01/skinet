<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <!-- Search input on the left -->
        <div class="d-flex align-items-center">
          <form class="d-flex" role="search">
            <input
              class="form-control me-2"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <button class="btn btn-outline-success" type="submit">
              <i class="bi bi-search"></i>
            </button>
          </form>
        </div>

        <!-- Centered logo/image -->
        <div class="mx-auto">
          <router-link class="navbar-brand" to="/"
            ><img src="../../assets/images/logo.png"
          /></router-link>
        </div>

        <!-- Login and Wishlist icons on the right -->
        <div class="d-flex align-items-center fs-2">
          <router-link class="nav-link" to="/basket">
            <!-- Link for wishlist -->
            <i class="bi bi-cart wishlist" /> {{ $store.state.basket.items.length }}
          </router-link>
          <!-- ِAccount dropstart button -->
          <div v-if="!userName" class="btn-group dropstart">
            <button
              type="button"
              class="btn dropdown-toggle border-0 fs-2"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              <i class="bi bi-person"></i>
            </button>
            <ul class="dropdown-menu">
              <li><router-link class="dropdown-item" to="/login">Login</router-link></li>
              <li>
                <router-link class="dropdown-item" to="/register">Register</router-link>
              </li>
              <li><hr class="dropdown-divider" /></li>
              <li><a class="dropdown-item" href="#">Something else here</a></li>
            </ul>
          </div>
          <div v-if="userName" id="loggedin">
            <b-dropdown :text="'Welcome ' + userName" class="m-2 fw-bold">
              <b-dropdown-item href="#">Action</b-dropdown-item>
              <b-dropdown-item href="#">Another action</b-dropdown-item>
              <b-dropdown-item> <b-button variant="primary" size="sm" @click="logOut()">log out</b-button></b-dropdown-item>
            </b-dropdown>
          </div>
        </div>
      </div>
    </nav>
    <nav class="navbar navbar-expand-lg bg-body-tertiary box">
      <div class="container-fluid">
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse container" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <router-link class="nav-link active" aria-current="page" to="/"
                >Home</router-link
              >
            </li>
            <li class="nav-item">
              <router-link class="nav-link active" aria-current="page" to="/shop"
                >Shop</router-link
              >
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
import AccountService from '@/account/service/account.service';
export default {
  computed: {
    userName() {
      return this.$store.state.currentUser?.displayName;
    },
  },
  methods: {
    logOut() {
      AccountService.logout();
      this.$store.commit('SET_CURRENT_USER', null);
      this.$router.push('/')
    },
  },
  created() {
    this.token = localStorage.getItem("token");
  },
};
</script>
<style>
.cart-no {
  position: absolute;
  min-height: 25px;
  min-width: 25px;
  border-radius: 50%;
  font-size: 1em;
  background: blue;
  color: white;
  text-align: center;
  top: -12px;
  right: 32px;
}
#loggedin .btn-secondary {
  background-color: transparent !important;
    color: black !important;
    border: none !important;
    font-weight: bold;
    border-radius: 5px !important;
    margin: 10px 25px 10px!important;
    cursor: pointer !important;
}

#loggedin .btn-secondary:hover {
  background-color: rgb(244, 203, 203) !important;
}
</style>
