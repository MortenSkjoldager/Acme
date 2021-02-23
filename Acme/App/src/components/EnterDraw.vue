<template>
    <div>
        <form class="" novalidate @submit.prevent="submitForm" :class="{ 'dirty': $v.$dirty, 'pristine': !$v.$dirty }">
            <div class="mb-3">
                <label for="firstName" class="form-label">First name</label>
                <input autocomplete="off" v-model="$v.form.firstName.$model" type="text" class="form-control" id="firstName" :class="status($v.form.firstName)">
                <div class="error validation-message" v-if="!$v.form.firstName.required">Please enter your first name</div>
            </div>
            <div class="mb-3">
                <label for="lastName" class="form-label">Last name</label>
                <input autocomplete="off" v-model="$v.form.lastName.$model" type="text" class="form-control" id="lastName" :class="status($v.form.lastName)">
                <div class="error validation-message" v-if="!$v.form.lastName.required">Please enter your Last name</div>
            </div>
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <input autocomplete="off" v-model="$v.form.email.$model" type="text" class="form-control" id="email" :class="status($v.form.email)">
                <div class="error validation-message" v-if="!$v.form.email.required">Email is required</div>
                <div class="error validation-message" v-if="!$v.form.email.email">Please enter a valid email.</div>
            </div>
            <div class="mb-3">
                <label for="serialNumber" class="form-label">Serial Number</label>
                <input autocomplete="off" v-model="$v.form.serialNumber.$model" type="text" class="form-control" id="serialNumber" :class="status($v.form.serialNumber)">
                <div class="error validation-message" v-if="!$v.form.serialNumber.required">Field is required</div>
                <div class="error validation-message" v-if="$v.form.serialNumber.required && !$v.form.serialNumber.validSerial">Serial number is not valid</div>
                <div class="error validation-message" v-if="$v.form.serialNumber.required && $v.form.serialNumber.validSerial && !$v.form.serialNumber.validSubmissionKey">Serial number already used for submission twice</div>
            </div>
            <div class="col-12">
                <button class="btn btn-primary" :disabled="$v.$invalid">Enter submission</button>
            </div>
        </form>
    </div>
</template>

<script>

    import axios from "axios";
    import {required, email} from 'vuelidate/lib/validators'
    import {validSerial, validSubmissionKey} from "../validators";
    
    export default {
        name: 'EnterDraw',
        data() {
            return {
                form: {
                    firstName: '',
                    lastName: '',
                    email: '',
                    serialNumber: ''
                }
            }
        },
        validations: {
            form: {
                firstName: {required},
                lastName: {required},
                email: {required, email},
                serialNumber: { required, validSerial, validSubmissionKey },
            }
        },
        methods: {
            submitForm: function () {
                axios.post('/api/submissions/create', {
                    FirstName: this.form.firstName,
                    LastName: this.form.lastName,
                    Email: this.form.email,
                    SerialNumber: this.form.serialNumber
                }).then(response => {
                    
                })
            },
            formState: function (validate) {
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

<style lang="stylus" scoped>

</style>
