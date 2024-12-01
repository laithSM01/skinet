<template>
    <div>  
      <!-- Modal -->
      <b-modal v-model="showModal" title="Success !" hide-header-close >
          <!-- Modal content goes here -->
          <p>{{ successMessage }}</p>
        <template v-slot:modal-footer>
          <!-- Modal footer with buttons -->
          <b-button variant="secondary" @click="closeModal">Close</b-button>
        </template>
      </b-modal>
    </div>
  </template>

<script>
export default {
    props: {
    showModal: {
      type: Boolean,
      required: true
    },
    successMessage: {
      type: String,
      default: 'Operation successful'
    }
    },
  methods: {
    closeModal() {
        this.$emit('update:showModal', false);
    },
  }
};
</script>