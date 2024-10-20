<template>
  <div id="signup">
    <div class="signup-form">
      <form @submit.prevent="onSubmit">
        <text-input
          id="username"
          label="Username"
          type="text"
          :value="username"
          :validation="validation"
          @input="username = $event"
          @blur="validateForm"
        ></text-input>

        <text-input
          id="email"
          label="Email"
          type="email"
          :value="email"
          :validation="validation"
          :isEmailExists="isEmailExists"
          :loading="loading"
          @input="email = $event; checkEmailExisting()"
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

        <text-input
          id="confirmPassword"
          label="Confirm Password"
          type="password"
          :value="confirmPassword"
          :validation="validation"
          :isPassConfirmed="isPassConfirmed"
          @input="confirmPassword = $event"
          @blur="validateForm"
        ></text-input>
        <div class="submit">
          <button
            :disabled="validation === 'inValid'"
            @click="validateForm"
            type="submit"
          >
            Submit
          </button>
        </div>
        <p v-if="hasErrors" class="error-message">
          <span v-for="(error, index) in errorMessages" :key="index">{{ error }}</span>
        </p>
      </form>
    </div>
  </div>
</template>

<script>
import TextInput from "../shared/components/text-input.vue";
import { mapState } from "vuex";
import AccountService from "./service/account.service";
export default {
  components: {
    TextInput,
  },
  data() {
    return {
      username: "",
      email: "",
      password: "",
      confirmPassword: "",
      validation: "pending",
      isPassConfirmed: false,
      isEmailExists: false,
      loading: false,
    };
  },
  computed: {
    ...mapState(["errorMessages"]),
    hasErrors() {
      return this.errorMessages.length > 0;
    },
    isEmailValid() {
        // Regular expression for validating email format
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        
        // Check if the email matches the pattern
        return emailPattern.test(this.email);
    }
  },
  methods: {
    validateForm() {
      if (
        this.username === "" ||
        this.email === "" ||
        this.password === "" ||
        this.confirmPassword === "" || 
        this.emailExists
      )
        this.validation = "inValid";
      if (this.email !== "" && this.password !== "") this.validation = "valid";
    },
    async checkEmailExisting() {
      if(this.isEmailValid) {
        this.loading = true
        const emailExists = await AccountService.checkEmailExists(this.email);
        setTimeout(() => {
          this.loading = false; // Hide loading indicator
          this.isEmailExists = emailExists.data
        }, 1000);
      }
      },
    async onSubmit() {
      const formData = {
        DisplayName: this.username,
        email: this.email,
        password: this.password,
        confirmPassword: this.confirmPassword,
      };
      if (this.password === this.confirmPassword) {
        this.isPassConfirmed = false;
        await this.$store.dispatch("signup", formData);
        if (!this.hasErrors) this.$router.push("/shop");
      } else {
        this.isPassConfirmed = true;
      }
    },
  },
};
</script>

<style scoped>
.signup-form {
  width: 400px;
  margin: 30px auto;
  border: 1px solid #eee;
  padding: 20px;
  box-shadow: 0 2px 3px #ccc;
}

.input {
  margin: 10px auto;
}

.input label {
  display: block;
  color: #4e4e4e;
  margin-bottom: 6px;
}

.input.inline label {
  display: inline;
}

.input input {
  font: inherit;
  width: 100%;
  padding: 6px 12px;
  box-sizing: border-box;
  border: 1px solid #ccc;
}

.input.inline input {
  width: auto;
}

.input input:focus {
  outline: none;
  border: 1px solid #521751;
  background-color: #eee;
}

.input select {
  border: 1px solid #ccc;
  font: inherit;
}

.hobbies button {
  border: 1px solid #521751;
  background: #521751;
  color: white;
  padding: 6px;
  font: inherit;
  cursor: pointer;
}

.hobbies button:hover,
.hobbies button:active {
  background-color: #8d4288;
}

.hobbies input {
  width: 90%;
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
