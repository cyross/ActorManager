
var app = new Vue({
    el: '#app',
    mounted: function () {
        this.updateCompleted(false)

        axios.get('/api/v1/ActorSpec/Index/')
            .then(function (response) {
                this.actor.names = response.data.Names

                // console.log(this.actor.names)

                this.actor.load_completed = true
            }.bind(this))
        axios.get('/api/v1/VoiceEngineSpec/Index/')
            .then(function (response) {
                this.ve.names = response.data.Names

                // console.log(this.ve.names)

                this.setupVEOptions()

                this.ve.load_completed = true
            }.bind(this))
        axios.get('/api/v1/ColorSpec/All/')
            .then(function (response) {
                this.color.specs = response.data.Specs

                this.setColorNames()
                this.setNameToColor()

                // console.log(this.color.dict)

                this.color.load_completed = true
            }.bind(this))
    },
    computed: {
        isLoadCompleted()
        {
            return this.actor.load_completed && this.ve.load_completed && this.color.load_completed
        },
        isShowActorAddButton()
        {
            return this.actor.edit.id == -1
        },
        isShowActorUpdateButton()
        {
            return this.actor.edit.id != -1
        },
        isShowVEAddButton()
        {
            return this.ve.edit.id == -1
        },
        isShowVEUpdateButton()
        {
            return this.ve.edit.id != -1
        },
        hasActorDetail()
        {
            return this.actor.detail.body != null
        },
        visibleActorDetail()
        {
            return this.actor.detail.body != null && !this.actor.edit.enable
        },
        hasAnotherNames()
        {
            return this.actor.detail.body.AnotherNames.length==0
        },
        hasVEDetail()
        {
            return this.ve.detail.body != null
        },
        visibleVEDetail()
        {
            return this.ve.detail.body != null && !this.ve.edit.enable
        },
    },
    methods: {
        updateCompleted(flag)
        {
            this.actor.load_completed = flag;
            this.ve.load_completed = flag;
            this.color.load_completed = flag;
        },
        setupVEOptions()
        {
            this.veOptions = []
            for(idx in this.ve.names)
            {
                this.ve.options.push({text: this.ve.names[idx].Name, value: this.ve.names[idx].Name})
            }
        },
        setColorNames()
        {
            this.color.names = []
            for(let i = 0; i < this.color.specs.length; i++)
            {
                var spec = this.color.specs[i]
                this.color.names.push(spec.Name)
            }
        },
        setNameToColor()
        {
            this.color.dict = {}
            for(let i = 0; i < this.color.specs.length; i++)
            {
                var spec = this.color.specs[i]
                this.color.dict[spec.Name] = spec
            }
        },
        showActorDetail: function (index) {
            axios.get(`/api/v1/ActorSpec/${index}/`)
                .then(function (response) {
                    this.actor.detail.index = index
                    this.actor.detail.body = response.data.Spec
                    // console.log(this.actor.detail.body)
                }.bind(this))
        },
        showVEDetail: function (index) {
            axios.get(`/api/v1/VoiceEngineSpec/${index}/`)
                .then(function (response) {
                    this.ve.detail.index = index
                    this.ve.detail.body = response.data.Spec
                    // console.log(this.ve.detail.body)
                }.bind(this))
        },
        strToColor: function(str) {
            if (str[0] == "#"){ return str }

            return this.color.dict[str].Hex
        },
        showNewActor: function () {
            this.actor.edit.id = -1
            this.actor.edit.name = ""
            this.actor.edit.kana = ""
            this.actor.edit.engines = []
            this.actor.edit.aliases = []
            this.setupColor(this.actor.edit.jimaku.text_color, "Black")
            this.setupColor(this.actor.edit.jimaku.outline_color, "White")
            this.actor.edit.jimaku.outline_width = 0
            this.setupColor(this.actor.edit.actor_name.text_color, "Black")
            this.setupColor(this.actor.edit.actor_name.outline_color, "White")
            this.actor.edit.actor_name.outline_width = 0
            this.actor.edit.ext_data = {}
            this.actor.edit.enable = true
        },
        showNewVE: function () {
            this.ve.edit.id = -1
            this.ve.edit.name = ""
            this.ve.edit.real_name = ""
            this.ve.edit.separator = ""
            this.ve.edit.encoding = ""
            this.ve.edit.ext_data = {}
            this.ve.edit.enable = true
        },
        showEditActor: function () {
            this.actor.edit.id = this.actor.detail.body.Id
            this.actor.edit.name = this.actor.detail.body.Name
            this.actor.edit.kana = this.actor.detail.body.Kana
            this.actor.edit.engines = this.actor.detail.body.Engines
            this.actor.edit.aliases = this.actor.detail.body.AnotherNames
            this.actor.edit.alias_text = this.actor.edit.aliases.join('\n')
            this.setupColor(this.actor.edit.jimaku.text_color, this.actor.detail.body.JimakuTextColor)
            this.setupColor(this.actor.edit.jimaku.outline_color, this.actor.detail.body.JimakuOutlineColor)
            this.actor.edit.jimaku.outline_width = this.actor.detail.body.JimakuOutlineWidth
            this.setupColor(this.actor.edit.actor_name.text_color, this.actor.detail.body.ActorTextColor)
            this.setupColor(this.actor.edit.actor_name.outline_color, this.actor.detail.body.ActorOutlineColor)
            this.actor.edit.actor_name.outline_width = this.actor.detail.body.ActorOutlineWidth
            this.actor.edit.ext_data = this.copyExt(this.actor.detail.body.ExtData)
            this.actor.edit.enable = true
        },
        showEditVE: function () {
            this.ve.edit.id = this.ve.detail.body.Id
            this.ve.edit.name = this.ve.detail.body.Name
            this.ve.edit.real_name = this.ve.detail.body.RealName
            this.ve.edit.separator = this.ve.detail.body.Separator
            this.ve.edit.encoding = this.ve.detail.body.Encoding
            this.ve.edit.ext_data = this.copyExt(this.ve.detail.body.ExtData)
            this.ve.edit.enable = true
        },
        hideEditActor: function () {
            this.actor.edit.enable = false
        },
        hideEditVE: function () {
            this.ve.edit.enable = false
        },
        addActorExt: function () {
            this.$set(this.actor.edit.ext_data, this.actor.edit.ext_key, this.actor.edit.ext_value)
            this.actor.edit.ext_key = ""
            this.actor.edit.ext_value = ""
        },
        deleteActorExt: function (key) {
            this.actor.edit.ext_data = this.filterExt(this.actor.edit.ext_data, key)
        },
        addVEExt: function () {
            this.$set(this.ve.edit.ext_data, this.ve.edit.ext_key, this.ve.edit.ext_value)
            this.ve.edit.ext_key = ""
            this.ve.edit.ext_value = ""
        },
        deleteVEExt: function (key) {
            this.ve.edit.ext_data = this.filterExt(this.ve.edit.ext_data, key)
        },
        applyActor: function() {
            this.actor.detail.body = {
                Id: this.actor.edit.id,
                Name: this.actor.edit.name,
                Kana: this.actor.edit.kana,
                Engines: this.actor.edit.engines,
                AnotherNames: this.actor.edit.alias_text.split('\n').map(alias => alias.trim()).filter(alias => alias.length != 0),
                JimakuTextColor: this.getColorFromInfo(this.actor.edit.jimaku.text_color),
                JimakuOutlineColor: this.getColorFromInfo(this.actor.edit.jimaku.outline_color),
                JimakuOutlineWidth: this.actor.edit.jimaku.outline_width,
                ActorTextColor: this.getColorFromInfo(this.actor.edit.actor_name.text_color),
                ActorOutlineColor: this.getColorFromInfo(this.actor.edit.actor_name.outline_color),
                ActorOutlineWidth: this.actor.edit.actor_name.outline_width,
                ExtData: this.copyExt(this.actor.edit.ext_data),
            }
        },
        addActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-add-actor')
        },
        appendActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-add-actor')
        },
        addActorOK: function () {
            this.applyActor()
            this.callAddApi('ActorSpec', this.actor)
        },
        updateActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-update-actor')
        },
        updateActorOK: function () {
            this.applyActor()
            this.callUpdateApi('ActorSpec', this.actor)
        },
        deleteActor: function () {
            this.actor.modal_info = this.actor.detail.body.Name
            this.$bvModal.show('confirm-delete-actor')
        },
        deleteActorOK: function () {
            this.callDeleteApi('ActorSpec', this.actor)
        },
        applyVE: function() {
            this.ve.detail.body = {
                Id: this.ve.edit.id,
                Name: this.ve.edit.name,
                RealName: this.ve.edit.real_name,
                Separator: this.ve.edit.separator,
                Encoding: this.ve.edit.encoding,
                ExtData: this.copyExt(this.ve.edit.ext_data),
            }
        },
        addVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-add-ve')
        },
        appendVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-add-ve')
        },
        addVEOK: function () {
            this.applyVE()
            this.callAddApi('VoiceEngineSpec', this.ve)
        },
        updateVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-update-ve')
        },
        updateVEOK: function () {
            this.applyVE()
            this.callUpdateApi('VoiceEngineSpec', this.ve)
        },
        deleteVE: function () {
            this.ve.modal_info = this.ve.detail.body.RealName + '(' + this.ve.detail.body.Name + ')'
            this.$bvModal.show('confirm-delete-ve')
        },
        deleteVEOK: function () {
            console.log('delete ve ok')
            this.callDeleteApi('VoiceEngineSpec', this.ve)
        },
        saveAll: function () {
            this.$bvModal.show('confirm-save-all')
        },
        saveAllOK: function () {
            console.log('copy all ok')
        },
        revertAll: function () {
            this.$bvModal.show('confirm-revert-all')
        },
        revertAllOK: function () {
            console.log('revert all ok')
            this.updateCompleted(false)
        },
        getColorType: function (color) {
            if(color[0] == '#'){ return 'rgb' }

            return 'named'
        },
        getColorRGB: function (color) {
            if(color[0] == '#'){ return color }

            return this.color.dict[color].Hex
        },
        setupColor: function(info, color){
            info.type = this.getColorType(color)
            info.name = color
            info.rgb = this.getColorRGB(color)
        },
        getColorFromInfo : function(info) {
            if(info.type === "named"){ return info.name }

            return info.rgb
        },
        selectChangedColor: function (color_info) {
            color_info.rgb = this.getColorRGB(color_info.name)
        },
        isColorIsNamed(color_info)
        {
            return color_info.type === 'named'
        },
        filterExt: function (ext_data, key) {
            if(key.length === 0){ return ext_data }
            if(key in ext_data === false){ return ext_data }

            new_ext_data = {}
            Object.keys(ext_data).forEach(k => { if( k !== key) { new_ext_data[k] = ext_data[k] }})
            return new_ext_data
        },
        callAddApi: function (spec_name, info) {
            var id = info.detail.body.id
            var name = info.detail.body.name
            axios.put(`/api/v1/${spec_name}/`, info.detail.body)
                .then(function (response) {
                    var new_id = response.data.NewId
                    info.names.push({Id: response.data.NewId, Name: name})
                    console.log(`add ${spec_name} ok`)
                    info.edit.enable = false
                    info.detail.id = -1
                    info.detail.body = null
                }.bind(this))
        },
        callUpdateApi: function (spec_name, info) {
            var id = info.detail.body.id
            var name = info.detail.body.name
            axios.post(`/api/v1/${spec_name}/${id}/`, info.detail.body)
                .then(function (response) {
                    var index = names.findIndex(n => n.Id == id)
                    this.$set(info.names, index, {Id: id, Name: name})
                    console.log(`update ${spec_name} ok`)
                    info.edit.enable = false
                    info.detail.id = -1
                    info.detail.body = null
                }.bind(this))
        },
        callDeleteApi: function (spec_name, info) {
            var id = info.detail.body.id
            axios.delete(`/api/v1/${spec_name}/${id}/`)
                .then(function (response) {
                    var index = names.findIndex(n => n.Id == id)
                    info.names.splice(index, 1)
                    console.log(`delete ${spec_name} ok`)
                    info.detail.id = -1
                    info.detail.body = null
                }.bind(this))
        },
        copyExt: function(org_ext_data) {
            var new_ext_data = {}
            Object.keys(org_ext_data).forEach(key => org_ext_data[key] = new_ext_data[key])
            return new_ext_data
        },
    },
    data: {
        actor: {
            load_completed: false,
            names: null,
            detail: {
                index: 0,
                body: null,
            },
            edit : {
                enable: false,
                id: -1,
                name: "",
                kana: "",
                engines: [],
                aliases: [],
                jimaku: {
                    text_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_width: 0,
                },
                actor_name: {
                    text_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_width: 0,
                },
                ext_data: {},
                alias_text: "",
                ext_key: "",
                ext_value: "",
            },
            request_data: {},
            modal_info: "",
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
        ve: {
            load_completed: false,
            names: null,
            detail: {
                index: 0,
                body: null,
            },
            options: [],
            edit: {
                enable: false,
                id: -1,
                name: "",
                real_name: "",
                separator: "",
                encoding: "",
                ext_data: {},
                ext_key: "",
                ext_value: "",
            },
            request_data: {},
            modal_info: "",
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
            encode_list: ['utf-8', 'shift_jis'],
            sep_list: [',', '＞'],
        },
        ve_san: {
            load_completed: false,
            edit: {},
        },
        ve_none: {
            load_completed: false,
            edit: {},
        },
        ve_sep: {
            load_completed: false,
            edit: {},
        },
        color: {
            load_completed: false,
            specs: null,
            names: [],
            dict: {},
        },
        mng: {
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
    }
})
