var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        process: [],
        cases: [],
        selectedProcess: {},
        editModProcess: '',
        gridProcess: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getProcess();
        self.getCases();
    },

    methods: {
        getProcess: function () {
            fetch('./api/Process/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.process = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

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

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModProcess = mode
            if (mode == "EDIT") {
                app.gridProcess = "Editar";
                app.selectedProcess = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.gridProcess = "Nuevo";
                app.selectedProcess = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedProcess.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedProcess.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
        },

        saveEdit: function () {
            var res = ''
            //validar
            //app.validateActionInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModProcess == "EDIT") {
                res = '/api/Process/update'
            }
            if (app.editModProcess == "NEW") {
                res = '/api/Process/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedProcess)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getProcess()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteAction: function (action) {
            app.modalVisibility = "block"
            app.selectedProcess = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Process/Delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedProcess)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getProcess()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})