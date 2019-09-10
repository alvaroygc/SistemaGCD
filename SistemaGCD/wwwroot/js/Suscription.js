var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        suscriptions: [],
        selectedSuscription: {},
        editModSuscription: '',
        gridSuscription: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getSuscriptions();
    },

    methods: {
        getSuscriptions: function () {
            fetch('./api/Suscription/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.suscriptions = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModSuscription = mode
            if (mode == "EDIT") {
                app.selectedSuscription = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.selectedSuscription = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedSuscription.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedSuscription.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
        },

        saveEdit: function () {
            var res = ''
            //validar
            app.validateActionInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModSuscription == "EDIT") {
                res = '/api/Suscription/update'
            }
            if (app.editModSuscription == "NEW") {
                res = '/api/Suscription/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedSuscription)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getSuscriptions()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteSuscription: function (action) {
            app.modalVisibility = "block"
            app.selectedSuscription = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Suscription/Delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedSuscription)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getSuscriptions()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})