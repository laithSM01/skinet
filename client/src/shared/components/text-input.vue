<template>
  <div class="input" :class="{ invalid: validation === 'inValid' && isTouched }">
    <label :for="id">{{ label }}</label>
    <div class="input-container">
      <input
        :type="type"
        :id="id"
        :value="value"
        @input="updateValue($event.target.value)"
        @blur="validate"
      />
      <p v-if="id === 'email' && isEmailExists" class="">
        Email is already in use
      </p>
      <div
        v-if="id === 'email'"
        class=""
        :class="{ 'spinner-border': loading }"
      ></div>
    </div>
    <p v-if="validation === 'inValid' && isTouched && value === ''">
      This field is required
    </p>
    <p v-if="isPassConfirmed && id === 'confirmPassword'">Confirm password please -.-</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isTouched: false, // Track if the input has been blurred
    };
  },
  props: {
    id: {
      type: String,
      required: true,
    },
    label: {
      type: String,
      required: true,
    },
    type: {
      type: String,
      default: "text",
    },
    value: {
      type: String,
      required: true,
    },
    validation: {
      type: String,
      required: true,
    },
    isPassConfirmed: {
      type: Boolean,
      default: false,
    },
    loading: {
      type: Boolean,
      default: false,
    },
    isEmailExists: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
    updateValue(newValue) {
      this.$emit("input", newValue);
    },
    validate() {
      this.isTouched = true;
      this.$emit("blur", this.id);
    },
  },
};
</script>

<style scoped>
.input label {
  display: block;
  color: #4e4e4e;
  margin-bottom: 6px;
}

.input input {
  font: inherit;
  width: 100%;
  padding: 6px 12px;
  box-sizing: border-box;
  border: 1px solid #ccc;
}

.input input:focus {
  outline: none;
  border: 1px solid #521751;
  background-color: #f08b8b;
}

.input p {
  color: red;
}

.invalid .input input {
  border-color: red;
}
.invalid .input p {
  color: red;
}
.spinner-border {
  position: absolute;
  right: 10px;
  top: 21%;
  font-size: 0.5rem;
  width: 25px;
  height: 25px;
  /* display: none; Initially hide the spinner */
}
.input-container {
  position: relative;
}
</style>
