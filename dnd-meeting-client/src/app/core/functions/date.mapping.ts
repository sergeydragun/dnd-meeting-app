import { TuiDay } from '@taiga-ui/cdk';

export function tuiDayToDate(tuiDay: TuiDay): Date {
    return new Date(tuiDay.year, tuiDay.month, tuiDay.day);
  }