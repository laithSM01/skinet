<template>
  <div id="app">
    <app-nav-bar></app-nav-bar>
    <app-section-header></app-section-header>
    <router-view />
  </div>
</template>

<script>
import navBar from "./core/components/nav-bar.vue"
import sectionHeader from "./core/components/SectionHeader"
export default {
  components: {
    appNavBar: navBar,
    appSectionHeader: sectionHeader
  }
}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
