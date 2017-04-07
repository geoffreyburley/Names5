namespace names5.Controllers {
    //====================================================
    export class HomeController {

        //================================================
        //Fields.
        //================================================
        //================================================
        //Properties.
        //================================================
        public message = 'Hello from the home page!';
        public names;
        //================================================
        //Constructor().
        //================================================
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`api/names`).then((response) => { this.names = response.data })
        }
        //================================================
        //Methods().
        //================================================
        public DeleteName(id: number) {
            this.$http.delete(`api/names/${id}`).then((response) => {
                this.$state.go(`home`);
                this.$state.reload();
            })
        }
    }
    //====================================================

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    //====================================================
    export class AboutController {
        //================================================
        //Field.
        //================================================
        //Properties.
        //================================================
        public message = 'Hello from the about page!';
        public name;

        //================================================
        //Constructor().
        //================================================
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.$http.get(`/api/names/` + this.$stateParams[`id`]).then((response) => { this.name = response.data; })
        }
        //================================================
        //Methods().
        //================================================
        public deleteAddress(id: number) {
            this.$http.delete(`/api/addresses/${id}`).then((response) => {
                this.$state.go('home');
                this.$state.reload();
            })

        }
        //================================================
        public addAddress(id: number) {

        }

        //================================================
    }
    //====================================================
    export class AddNameController {
        //================================================
        //Fields.  
        //================================================
        //================================================
        //Properties.
        //================================================
        //vnnameaddress represents a View Model class descrbed in the server under the ViewModels folder.
        //It contains fields tht area composite of the Name and Address models. 
        //vnmnameaddress is used on the addName.html page.     
        public vmnameaddress;
        public address;
        //================================================
        //================================================
        //Constructor().
        //================================================
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
        }

        //================================================
        //Methods().
        //================================================
        public addNameAddresses() {
            this.$http.post(`api/nameaddresses`, this.vmnameaddress).then((response) => { this.$state.go(`home`); })
        }
        //====================================================
    }
    export class EditNameController {
        //Fields.
        //Properties.
        public message = 'Hello from the edit movie page!';
        
        public name;


        //Constructor().
        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.$http.get(`api/names/` + this.$stateParams[`id`]).then((response) => {
                this.name = response.data;
            })

        }
       
        //Methods().
        public editName(id: number) {
            this.$http.post(`/api/names`, this.name).then((response) => {
                this.$state.go(`home`);
            })

        }
        ////Methods().
        //public editName(id: number) {
        //    this.$http.post(`/api/names`, this.name).then((response) => {
        //        this.$state.go(`about/:id`);
        //    })

        //}

    }
    export class EditAddressController {
        //Fields.
        //Properties.
        public message = 'Hello from the edit address page!';

        public address;


        //Constructor().
        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.$http.get(`api/addresses/` + this.$stateParams[`id`]).then((response) => {
                this.address = response.data;
            })

        }

        //Methods().
        public editAddress(id: number) {
            this.$http.post(`/api/addresses`, this.address).then((response) => {
                this.$state.go(`home`);
            })

        }
        ////Methods().
        //public editAddress(id: number) {
        //    this.$http.post(`/api/addresses`, this.address).then((response) => {
        //        this.$state.go(`about/:id`);
        //    })

    }
    //====================================================  
    export class AddAddressUnderNameController{
        //================================================
        //Fields.  
        //================================================
        //================================================
        //Properties.
        //================================================
        //vnnameaddress represents a View Model class descrbed in the server under the ViewModels folder.
        //It contains fields tht area composite of the Name and Address models. 
        //vnmnameaddress is used on the addName.html page.     
        
        public vmnameaddress;
        public name;
        //================================================
        //================================================
       
        //Constructor().
        //================================================
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.$http.get(`/api/names/` + this.$stateParams[`id`]).then((response) => { this.name = response.data; });
        }
        //================================================

        //================================================
        //Methods().
        //================================================
        public addAddressUnderName() {
            this.vmnameaddress.NameId = this.name.id;
            this.vmnameaddress.FirstName = this.name.firstName;
            this.vmnameaddress.LastName = this.name.lastName;
            this.vmnameaddress.DateOfBirth = this.name.dateOfBirth;
            this.vmnameaddress.FatherId = this.name.fatherId;
            this.vmnameaddress.MotherId = this.name.motherId;


            this.$http.post(`api/nameaddresses`, this.vmnameaddress).then((response) => { this.$state.go(`home`); });
        }
        //====================================================

    }

    //====================================================
    export class AdminController {
        //================================================
        //Fields.  
        //================================================
        //================================================
        //Properties.
        //================================================
        public names;
        //================================================
        //Constructor().
        //================================================
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`api/names`).then((response) => { this.names = response.data })
        }
        //================================================
        //Method().
        //================================================

    }
    
}