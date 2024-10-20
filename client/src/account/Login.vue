<template>
    <div id="signin">
    <div class="signin-form">
      <form @submit.prevent="onSubmit">
        <text-input
          id="email"
          label="Email"
          type="email"
          :value="email"
          :validation="validation"
          @input="email = $event"
          @blur="validateForm"
        ></text-input>

        <text-input
          id="password"
          label="Password"
          type="password"
          :value="password"
          :validation="validation"
          @input="password = $event"
          @blur="validateForm"
        ></text-input>

        <div class="submit">
          <button type="submit" @click="validateForm" :disabled="validation === 'inValid'">Submit</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import TextInput from '../shared/components/text-input.vue'
export default {
  components: {
    TextInput
  },
    data() {
        return{
        email: '',
        password: '',
        validation: 'pending'
        }
    },
    created() {
    },
    methods: {
      createForm() {
        const loginForm = {
          email: this.email,
          password: this.password,
        }
        return loginForm;
      },
      validateForm() {
      if(this.email === '' || this.password === '')
        this.validation = 'inValid'
      if(this.email !== '' && this.password !== '')
        this.validation = 'valid'
      },
        onSubmit() {
          this.createForm();
        if(this.email !== '' && this.password !== '') {
          this.$store.dispatch('login', this.createForm());
          this.$router.push('/shop')
        }
        }
    }
}
</script>

<style scoped>
  .signin-form {
    width: 400px;
    margin: 30px auto;
    border: 1px solid #eee;
    padding: 20px;
    box-shadow: 0 2px 3px #ccc;
  }

  .input {
    margin: 10px auto;
  }

  .submit button {
    border: 1px solid #521751;
    color: #521751;
    padding: 10px 20px;
    font: inherit;
    cursor: pointer;
  }

  .submit button:hover,
  .submit button:active {
    background-color: #521751;
    color: white;
  }

  .submit button[disabled],
  .submit button[disabled]:hover,
  .submit button[disabled]:active {
    border: 1px solid #ccc;
    background-color: transparent;
    color: #ccc;
    cursor: not-allowed;
  }
</style>