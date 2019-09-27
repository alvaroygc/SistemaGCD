var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        process_field: [],
        data_types: [],
        process: [],
        selectedProcess_Field: {},
        editModProcess_Field: '',
        gridProcess_Field: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getProcess_Field();
        self.getProcess();
        self.getData_Types();
    },

    methods: {
        getProcess_Field: function () {
            fetch('./api/Process_Field/getall', {
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
                        app.process_field = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        getProcess: function () {
            fetch('./api/Process/getall', {
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
                        app.process = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        getData_Types: function () {
            fetch('./api/Data_Type/getall', {
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
                        app.data_types = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModProcess_Field = mode
            if (mode == "EDIT") {
                app.gridProcess_Field = "Editar";
                app.selectedProcess_Field = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.gridProcess_Field = "Nuevo";
                app.selectedProcess_Field = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            var v_Archive = "^ Yes | No | N\/A \(over 21\)$";

            if (app.selectedProcess_Field.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedProcess_Field.archive != v_Archive) {
                app.inputErrors.push('Ingrese Si o NO!');
            }
           
        },

        saveEdit: function () {
            var res = ''
            //validar
            //app.validateActionInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModProcess_Field == "EDIT") {
                res = '/api/Process_Field/update'
            }
            if (app.editModProcess_Field == "NEW") {
                res = '/api/Process_Field/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json",
                    "LoggedUser": sessionStorage.getItem("Id")
                },
                body: JSON.stringify(app.selectedProcess_Field)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getProcess_Field()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteAction: function (action) {
            app.modalVisibility = "block"
            app.selectedProcess_Field = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Process_Field/Delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json",
                        "LoggedUser": sessionStorage.getItem("Id")
                    },
                    body: JSON.stringify(app.selectedProcess_Field)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getProcess_Field()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})