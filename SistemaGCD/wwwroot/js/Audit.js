var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        audit: [],
        selectedAction: {},
        editModAction: '',
        gridAction: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getAudit();

    },

    methods: {
        getAudit: function () {

            fetch('./api/Audit/getall', {
                method: 'GET',
                headers: {
                    'LoggedUser': sessionStorage.getItem('Id')
                }
            })
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);

                        return;
                    }
                    response.json().then(function (data) {
                        app.audit = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },


    }
})