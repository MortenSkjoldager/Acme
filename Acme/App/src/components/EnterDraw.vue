<template>
    <div class="www">
        <form class="row g-3 needs-validation" :class="{ 'dirty': $v.$dirty }" novalidate>
            <div class="col-md-4" :class="{ 'error': $v.firstName.$error, 'dirty': $v.firstName.$dirty }">
                <label for="firstName" class="form-label">First name</label>
                <input v-model="$v.firstName.$model" type="text" class="form-control" id="firstName" :class="status($v.firstName)">
                <div class="error" v-if="!$v.firstName.required">Field is required</div>
                <div class="error" v-if="!$v.firstName.minLength">Field should be coorect</div>
                <div class="valid" v-if="!$v.firstName.$error">Looks good!</div>
            </div>
            <div class="col-12">
                <button class="btn btn-primary" v-on:click="submitForm($event)">Submit form</button>
            </div>
        </form>
    </div>
</template>

<script>

    import {required, minLength} from 'vuelidate/lib/validators'

    export default {
      name: 'EnterDraw',
      data() {
        return {
          firstName: ''
        }
      },
      validations: {
        firstName: {
          required,
          minLength: minLength(4)
        },
      },
      methods: {
        submitForm: function (e) {
          alert(this.firstName)
          e.preventDefault()
        },
        formState: function(validate) {
          if (validate.$dirty) return ''
        },
        status(validation) {
          return {
            error: validation.$error,
            dirty: validation.$dirty
          }
        }
      }
    }
</script>

<style scoped>

</style>
