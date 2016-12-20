var NutritionInfo = NutritionInfo || (function () {

    var drawMultilineText = function (canvas, text, posX, posY, lineHeight) {
        var sections = text.replace(/(\r\n|\n\r|\r|\n)/g, "\n").replace(/(\t)/g, "    ").split("\n");
        for (var sectionIndex = 0, currentPosY = posY; sectionIndex < sections.length;) {
            canvas.fillText(sections[sectionIndex], posX, currentPosY);
            sectionIndex++;
            currentPosY += lineHeight;
        }
    }

    var self = null;
    var view = {

        urls: {
            canvasBackground: null
        },
        data: {
        },
        elements: {
            canvas: null,
            form: null,
        },

        FormInputChanged: function () {

            self.elements.canvas.setAttribute('width', self.elements.canvas.offsetWidth);
            self.elements.canvas.setAttribute('height', self.elements.canvas.offsetHeight);

            var ctx = self.elements.canvas.getContext('2d');
            ctx.clearRect(0, 0, self.elements.canvas.width, self.elements.canvas.height);

            var img = new Image();
            img.onload = function () {
                ctx.drawImage(img, 0, 0);

                ctx.font = "600 12px sans-serif";
                drawMultilineText(ctx, self.elements.form.find("textarea[name=Description]").val(), 16, 58, 13);

                ctx.font = "600 15px sans-serif";
                ctx.fillText(self.elements.form.find("input[name=ServingSize]").val(), 90, 103);
                ctx.fillText(self.elements.form.find("input[name=ServingPerContainer]").val(), 145, 122);

                ctx.fillText('' + self.elements.form.find("input[name=Calories]").val(), 65, 175);
                ctx.fillText('' + self.elements.form.find("input[name=CaloriesFat]").val(), 201, 175);
                ctx.fillText('' + self.elements.form.find("input[name=TotalFat]").val(), 83, 222);
                ctx.fillText('' + self.elements.form.find("input[name=SatFat]").val(), 112, 246);
                ctx.fillText('' + self.elements.form.find("input[name=TransFat]").val(), 88, 269);
                ctx.fillText('' + self.elements.form.find("input[name=PolyFat]").val(), 150, 294);
                ctx.fillText('' + self.elements.form.find("input[name=MonoFat]").val(), 157, 318);
                ctx.fillText('' + self.elements.form.find("input[name=Cholesterol]").val(), 100, 341);
                ctx.fillText('' + self.elements.form.find("input[name=Sodium]").val(), 70, 364);
                ctx.fillText('' + self.elements.form.find("input[name=Carbs]").val(), 165, 388);
                ctx.fillText('' + self.elements.form.find("input[name=Protein]").val(), 70, 411);

                ctx.fillText('' + self.elements.form.find("input[name=VitA]").val(), 74, 445);
                ctx.fillText('' + self.elements.form.find("input[name=VitC]").val(), 193, 445);
                ctx.fillText('' + self.elements.form.find("input[name=Calcium]").val(), 65, 468);
                ctx.fillText('' + self.elements.form.find("input[name=Iron]").val(), 186, 468);

                ctx.textAlign = "end";
                ctx.fillText('' + (((self.elements.form.find("input[name=TotalFat]").val()) / 65) * 100).toFixed(0) +'%', 215, 222);
                ctx.fillText('' + (((self.elements.form.find("input[name=SatFat]").val()) / 20) * 100).toFixed(0) + '%', 215, 246);
                ctx.fillText('' + (((self.elements.form.find("input[name=TransFat]").val()) / 2000) * 100).toFixed(0) + '%', 215, 269);
                ctx.fillText('' + (((self.elements.form.find("input[name=PolyFat]").val()) / 2000) * 100).toFixed(0) + '%', 215, 294);
                ctx.fillText('' + (((self.elements.form.find("input[name=MonoFat]").val()) / 2000) * 100).toFixed(0) + '%', 215, 318);

                //ctx.fillText('' + (((self.elements.form.find("input[name=Cholesterol]").val() * 4)/2000)*100).toFixed(0)+'%', 215, 300);
                //ctx.fillText('' + (((self.elements.form.find("input[name=Sodium]").val() * 4)/2000)*100).toFixed(0)+'%', 215, 323);
                ctx.fillText('' + (((self.elements.form.find("input[name=Carbs]").val()) / 300) * 100).toFixed(0) + '%', 215, 388);
                //ctx.fillText('' + (((self.elements.form.find("input[name=Protein]").val() * 4) / 2000) * 100).toFixed(0)+'%', 215, 411);
            };
            img.src = self.urls.canvasBackground;
        },

        Init: function (params) {
            self.urls = params.urls || self.urls;
            self.data = params.data || self.data;
            self.elements = params.elements || self.elements;

            self.elements.form.find("input").change(self.FormInputChanged);
            self.elements.form.find("textarea").change(self.FormInputChanged);
            self.FormInputChanged();
        }
    };

    self = view;
    return view;
})();

var CustomersInfo = CustomersInfo || (function () {

    var self = null;
    var view = {
        urls: {
            update: null
        },
        data: {

        },
        elements: {
            pager: null,
            template: null,
        },

        Init: function (params) {
            self.urls = params.urls || self.urls;
            self.data = params.data || self.data;
            self.elements = params.elements || self.elements;

            var dataSource = new kendo.data.DataSource({
                autoSync: true,
                transport: {
                    read: {
                        url: self.urls.update
                    }
                },
                schema: {
                    model: { name: "Name", Id: "Id" }
                }
            });

            //self.elements.pager.kendoPager({
            //    dataSource: dataSource,
            //    pageSizes: [10, 25, 50],
            //    selectTemplate: self.elements.template.html(),
            //});

            dataSource.read();

            self.elements.pager.kendoListView({
                template: self.elements.template.html(),
                dataSource: dataSource,
            });
        }
    };

    self = view;
    return view;
})();