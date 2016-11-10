new Vue({
    el: 'body',

    components: {
        confirm: {
            props: {
                class: String,
                sureClass: String,
                func: {
                    type: Function,
                    required: true
                }
            },

            data: function () {
                return {
                    confirm: false
                };
            },

            template: '#confirm-template',


        }
    },

    methods: {
        alert: function () {
            alert("Trigger external method");
        }
    }
})