var Schedule = function() {


    var initSchedule = function() {

        //var a = moment().subtract(-1, 'day');
        //alert(a.format("YYYY-MM-DD hh:mm:ss"));

        scheduledateTable._render();
        scheduledateTable._back();
        // alert(data.items.length);

        $('#datepaginator_sample_1').datepaginator();


    };


    var scheduledateTable = {
        options: {
            selectedDateFormat: 'YYYY-MM-DD',
            textSelected: 'dddd<br/>Do, MMMM YYYY',
            text: 'ddd<br/>Do',
            offDays: 'Sat,Sun',
            selectedDate: moment().clone().startOf('day'),
            startOfWeek: 'Mon',
            startOfWeekFormat: 'ddd',
            startDate: moment(new Date(-8640000000000000)),
            endDate: moment(new Date(8640000000000000))
        },
        _init: function() {


        },
        _setSelectedDate: function (selectedDate) {
            if ((!selectedDate.isSame(this.options.selectedDate)) &&
				(!selectedDate.isBefore(this.options.startDate)) &&
				(!selectedDate.isAfter(this.options.endDate))) {
                this.options.selectedDate = selectedDate.startOf('day');
                //this.$element.trigger('selectedDateChanged', [selectedDate.clone()]);
            }
        },
        _forward: function () {
            this._setSelectedDate(this.options.selectedDate.clone().add('day', 7));
            this._render();
        },
        _back: function () {
            this._setSelectedDate(this.options.selectedDate.clone().subtract('day', 7));
            this._render();
        },
        _render: function() {
            var self = this;

            this.$element = $("#datepaginator_sample_2");
            this.$wrapper = $(this._template.table);
            this.$thead = $(this._template.thead);
            this.$tbody = $(this._template.tbody);


            // Get data then string together DOM elements
            var data = this._buildData();
            this.$element.empty().append(this.$wrapper.empty());
            this.$wrapper.append(this.$thead.empty());

            // Items
            var $htr = $(this._template.tr);
            this.$thead.append($htr.empty());
            $.each(data.items, function(id, item) {

                var $td = $(self._template.td).attr('data-moment', item.m);
                $td.append(item.text);
                $htr.append($td);

            });

        },

        _buildData: function() {

            var today = moment().startOf('day'),
                start = this.options.selectedDate.clone().subtract('days', 3),
                end = this.options.selectedDate.clone().add('days', 4);

            var data = {
                isSelectedStartDate: this.options.selectedDate.isSame(this.options.startDate) ? true : false,
                isSelectedEndDate: this.options.selectedDate.isSame(this.options.endDate) ? true : false,
                items: []
            };

            for (var m = start; m.isBefore(end); m.add('days', 1)) {
                var valid = ((m.isSame(this.options.startDate) || m.isAfter(this.options.startDate)) &&
                (m.isSame(this.options.endDate) || m.isBefore(this.options.endDate))) ? true : false;

                data.items[data.items.length] = {
                    m: m.clone().format(this.options.selectedDateFormat),
                    isValid: valid,
                    isSelected: (m.isSame(this.options.selectedDate)) ? true : false,
                    isToday: (m.isSame(today)) ? true : false,
                    isOffDay: (this.options.offDays.split(',').indexOf(m.format(this.options.offDaysFormat)) !== -1) ? true : false,
                    isStartOfWeek: (this.options.startOfWeek.split(',').indexOf(m.format(this.options.startOfWeekFormat)) !== -1) ? true : false,
                    text: (m.isSame(this.options.selectedDate)) ? m.format(this.options.textSelected) : m.format(this.options.text),
                };
            }
            return data;
        },

        _template: {
            table: '<table></table>',
            thead: '<thead></thead>',
            tbody: '<tbody></tbody>',
            tr: '<tr></tr>',
            td: '<td></td>',
            calendar: '<i id="dp-calendar" class="glyphicon glyphicon-calendar"></i>'
        }
    };


    return {
        //main function to initiate the module
        init: function() {
            initSchedule();
        }
    };
}();