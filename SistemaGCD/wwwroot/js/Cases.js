var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        cases: [],
        status: [],
        selectedCases: {},
        editModCases: '',
        gridCases: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getCases();
        self.getStatus();
    },

    methods: {
        getCases: function () {
            fetch('./api/Cases/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.cases = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        getStatus: function () {
            fetch('./api/Status/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.status = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModCases = mode
            if (mode == "EDIT") {
                app.selectedCases = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.selectedCases = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedCases.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedCases.description == '') {
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
            if (app.editModCases == "EDIT") {
                res = '/api/Cases/update'
            }
            if (app.editModCases == "NEW") {
                res = '/api/Cases/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedCases)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getCases()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteCases: function (action) {
            app.modalVisibility = "block"
            app.selectedCases = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Cases/Delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedCases)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getCases()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})