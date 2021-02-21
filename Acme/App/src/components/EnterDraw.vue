<template>
    <div>
        <form class="" novalidate @submit.prevent="submitForm" :class="{ 'dirty': $v.$dirty, 'pristine': !$v.$dirty }">
            <div>
                <label for="serialNumber" class="form-label">Serial Number</label>
                <input autocomplete="off" v-model="$v.form.serialNumber.$model" type="text" class="form-control" id="serialNumber" :class="status($v.form.serialNumber)">
                <div class="error validation-message" v-if="!$v.form.serialNumber.required">Field is required</div>
                <div class="error validation-message" v-if="$v.form.serialNumber.required && !$v.form.serialNumber.validSerial">Serial number is not valid</div>
                <div class="error validation-message" v-if="$v.form.serialNumber.required && $v.form.serialNumber.validSerial && !$v.form.serialNumber.validSubmissionKey">Serial number already used for submission twice</div>
            </div>
            <div class="col-12">
                <button class="btn btn-primary" :disabled="$v.$invalid" v-on:click="submitForm($event)">Submit form</button>
            </div>
        </form>
    </div>
</template>

<script>

    import {required} from 'vuelidate/lib/validators'
    import {validSerial, validSubmissionKey} from "../validators";
    
    export default {
        name: 'EnterDraw',
        data() {
            return {
                form: {
                    serialNumber: ''
                },
                serverErrors: {}
            }
        },
        validations: {
            form: {
                serialNumber: { required, validSerial, validSubmissionKey },
            }
        },
        methods: {
            submitForm: function () {
                
                console.log(this.$v)
                this.$v.$touch()
                // But clear server errors as they shouldn't prevent re-submission
                console.log('required ', this.$v.form.serialNumber.required);
                console.log('submissionKey ', this.$v.form.serialNumber.validSubmissionKey);
                console.log('validSerial', this.$v.form.serialNumber.validSerial);
                this.$v.form.serialNumber.serverError = false;
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
