import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

declare var $: any;
import * as moment from 'moment';



@Injectable()
export class HelperProvider {

    private Error = 'error';
    private Success = 'success';
    private Information = 'info';
    private Warning = 'warning';

    constructor(private toastrService: ToastrService) {

    }

    public isNull(value: any): boolean {
        if (value != null && value !== '' && value !== -1 && typeof value !== 'undefined') {
            return false;
        }
        return true;
    }

    public equalsIgnoreCase(value, comparer): boolean {
        return this.ToUpper(value).trim() === this.ToUpper(comparer).trim();
    }

    public ToUpper(value): string {
        if (this.isNull(value)) {
            return '';
        }
        return value.toUpperCase();
    }

    public FromDateToText(date): string {
        return (date.getDate() < 10 ? '0' + date.getDate() : date.getDate()) + '/' +
            ((date.getMonth() + 1) < 10 ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1)) + '/'
            + date.getFullYear();
    }

    public FromDateToTime(date): string {
        return ((date.getHours()) < 10 ? '0' + (date.getHours()) : (date.getHours())) + ':' +
            ((date.getMinutes()) < 10 ? '0' + (date.getMinutes()) : (date.getMinutes()));
    }

    public FromTextToDate(type, text): Date {
        let date = new Date(2000, 1, 1);
        if (!this.isNull(text)) {
            switch (type) {
                case 'short': {
                    const text_splitA = text.split('/');
                    const dayA = Number(text_splitA[0]);
                    const monthA = Number(text_splitA[1]) - 1;
                    const yearA = Number(text_splitA[2]);
                    date = new Date(yearA, monthA, dayA);
                    }
                    break;

                case 'full':
                const date_splitB = text.substring(0, 10).split('/');
                const dayB = Number(date_splitB[0]);
                    const monthB = Number(date_splitB[1]) - 1;
                    const yearB = Number(date_splitB[2]);
                    const hour_splitB = text.substring(11, 16).split(':');
                    const hourB = Number(hour_splitB[0]);
                    const minuteB = Number(hour_splitB[1]) - 1;
                    date = new Date(yearB, monthB, dayB, hourB, minuteB);
                    break;

                case 'with-seconds':
                    const date_split = text.substring(0, 10).split('/');
                    const day = Number(date_split[0]);
                    const month = Number(date_split[1]) - 1;
                    const year = Number(date_split[2]);
                    const hour_split = text.substring(11, 19).split(':');
                    const hour = Number(hour_split[0]);
                    const minute = Number(hour_split[1]);
                    const seconds = Number(hour_split[2]);
                    date = new Date(year, month, day, hour, minute, seconds);

            }
        }

        return date;
    }

    public DateFormat(text): string {
        const day = text.substring(0, 2);
        const month = text.substring(3, 5);
        const year = text.substring(6, 10);
        return year + '-' + month + '-' + day;
    }

    private Notify(type, title, message, timeout): void {
        this.toastrService[type](message, title, {
            timeOut: timeout
        });
    }

    public ShowMessage(type, title, message, time): void {
        const timeOut = !this.isNull(time) ? time : 3000;
        switch (type) {
            case TypeMessage.Error:
                this.Notify(this.Error, title, message, timeOut);
                break;
            case TypeMessage.Success:
                this.Notify(this.Success, title, message, timeOut);
                break;
            case TypeMessage.Information:
                this.Notify(this.Information, title, message, timeOut);
                break;
            case TypeMessage.Warning:
                this.Notify(this.Warning, title, message, timeOut);
                break;
        }
    }

    public GroupBy<T>(data: Array<T>, prop: any): Array<T[]> {
        const values = data.reduce(function (groups, item) {
            const val = item[prop];
            groups[val] = groups[val] || [];
            groups[val].push(item);
            return groups;
        }, []);
        return values;
    }

    public Join<T>(data: Array<T>, prop: any): Array<T> {
        const datos = data.reduce(function (groups, item) {
            const val = item[prop];
            groups[val] = groups[val] || [];
            groups[val].push(item);
            return groups;
        }, []);

        const group = [];
        for (const item of datos) {
            if (!this.isNull(item)) {
                group.push(item[0]);
            }
        }
        return group;
    }

    public openRevealCard(idParent: string): void {
        if (!this.isNull(idParent)) {
          const $card = $(idParent).find('.card');
            if (!this.isNull($card)) {
              const $cardReveal = $card.find('.card-reveal');
                if (!this.isNull($cardReveal)) {
                    $card.css({ overflow: 'hidden' });
                    $($cardReveal[0]).css({ display: 'block' });
                    // $cardReveal.removeClass('slideOutRight').addClass('slideInLeft');
                    $($cardReveal[0]).removeClass('zoomOut').addClass('zoomIn');
                }
            }
        }
    }

    public openReveal(id: string) {
      const $cardReveal = $(id);
        $cardReveal.css({ display: 'block' });
        $cardReveal.removeClass('zoomOut').addClass('zoomIn');
    }

    public closeReveal(id: string) {
      const $cardReveal = $(id);
        $cardReveal.removeClass('zoomIn').addClass('zoomOut');

        setTimeout(() => {
            $cardReveal.css({ display: 'none' });
        }, 1000);
    }

    public closeRevealCard(id: string) {
        if (!this.isNull(id)) {
          const $card = $(id).find('.card');
            if (!this.isNull($card)) {
              const $cardReveal = $card.find('.card-reveal');
                if (!this.isNull($cardReveal)) {
                    $card.css('overflow', 'visible');
                    // $cardReveal.removeClass('slideOutRight').addClass('slideInLeft');
                    $cardReveal.removeClass('zoomIn').addClass('zoomOut');

                    setTimeout(() => {
                        $cardReveal.css({ display: 'none' });
                    }, 1000);

                }
            }

        }
    }

    public toggleAccordion(id: string): void {
        if (!this.isNull(id)) {
            $(id).find('.widget-buttons a[data-toggle=collapse]').trigger('click');
        }
    }

    public openModal(nameModal): void {
      const modal = !this.isNull(nameModal) ? $(nameModal) : '';
        if (modal !== '') {
            modal.modal('show');
        }
    }

    public closeModal(nameModal): void {
        const modal = !this.isNull(nameModal) ? $(nameModal) : '';
        if (modal !== '') {
            modal.modal('hide');
        }
    }

    public InitToolTip(): void {
        $('[data-toggle=tooltip]').tooltip();
    }

    public showToolTip(name): void {
        const $toolTip = !this.isNull(name) ? $(name) : '';
        if ($toolTip !== '') {
            $toolTip.tooltip('show');
        }
    }

    public hideToolTip(name): void {
        const $toolTip = !this.isNull(name) ? $(name) : '';
        if ($toolTip !== '') {
            $toolTip.tooltip('hide');
        }
    }

    public CarouselInitInterval(interval: number): void {
        const time = this.isNull(interval) ? 3000 : interval;
        $('.carousel').carousel({
            interval: time
        });
    }
}
export enum TypeMessage {
    Error,
    Success,
    Information,
    Warning
}
