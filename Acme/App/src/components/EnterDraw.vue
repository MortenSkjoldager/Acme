<template>
<!--    <div>-->
    <!--        <form class="row g-3 needs-validation" :class="{ 'dirty': $v.$dirty, 'pristine': !$v.$dirty }" novalidate>-->
    <!--            <div class="col-md-4" :class="{ 'error': $v.form.firstName.$error, 'dirty': $v.form.firstName.$dirty }">-->
    <!--                <label for="firstName" class="form-label">First name</label>-->
    <!--                <input v-model="$v.form.firstName.$model" type="text" class="form-control" id="firstName"-->
    <!--                       :class="status($v.form.firstName)">-->
    <!--                <div class="error validation-message" v-if="!$v.form.firstName.required">Field is required</div>-->
    <!--                <div class="error validation-message" v-if="!$v.form.firstName.minLength">Field should be coorect</div>-->
    <!--                <div class="error validation-message" v-if="!$v.form.firstName.serverError">Unique name pls</div>-->
    <!--                <div class="valid validation-message" v-if="!$v.form.firstName.$error">Looks good!</div>-->
    <!--            </div>-->
    <!--            <div class="col-12">-->
    <!--                <button class="btn btn-primary" v-on:click="submitForm($event)">Submit form</button>-->
    <!--            </div>-->
    <!--        </form>-->
    <!--    </div>-->

        <div>
            <form class="" novalidate @submit.prevent="submitForm" :class="{ 'dirty': $v.$dirty, 'pristine': !$v.$dirty }">
                <div>
                    <label for="firstName" class="form-label">First name</label>
                    <input autocomplete="off" v-model="$v.form.firstName.$model" type="text" class="form-control" id="firstName" :class="status($v.form.firstName)">
                    <div class="error validation-message" v-if="!$v.form.firstName.required">Field is required</div>
                    <div class="error validation-message" v-if="!$v.form.firstName.uniqueMail">Unique name pls</div>
                </div>
                <div class="col-12">
                    <button class="btn btn-primary" v-on:click="submitForm($event)">Submit form</button>
                </div>
            </form>
        </div>
</template>

<script>

    import {merge} from 'lodash'
    import {required, minLength} from 'vuelidate/lib/validators'
    import {uniqueMail} from "../validators";
    
    export default {
        name: 'EnterDraw',
        data() {
            return {
                form: {
                    firstName: ''
                },
                serverErrors: {}
            }
        },
        validations: {
            form: {
                firstName: { required, uniqueMail },
            }
        },
        methods: {
            submitForm: function () {
                this.$v.$touch()
                // But clear server errors as they shouldn't prevent re-submission
                // this.$v.form.firstName.$error = true;
                debugger;

                this.$v.form.firstName.serverError = false;
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
