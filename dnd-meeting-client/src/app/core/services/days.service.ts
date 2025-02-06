import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { NotificationService } from './notification.service';
import { map, Observable } from 'rxjs';
import { FreeDay } from '../models/freeday.model';
import gql from 'graphql-tag';
import { FreeTime } from '../models/freetime.model';

@Injectable()
export class DaysService {
  constructor(
    private readonly apollo: Apollo,
    private readonly notify: NotificationService
  ) {}

  loadDays(usersIds: string[]): Observable<FreeDay[]> {
    const GET_DAYS = gql`
      query UsersByIds($ids: [UUID!]!) {
        usersByIds(ids: $ids) {
          nodes {
            daysWithFreeTime {
              id
              date
            }
          }
        }
      }
    `;

    return this.apollo
      .watchQuery<{ usersByIds: { nodes: { daysWithFreeTime: FreeDay[] }[] } }>(
        {
          query: GET_DAYS,
          variables: { ids: usersIds },
        }
      )
      .valueChanges.pipe(
        map((result) => {
          return result.data.usersByIds.nodes.flatMap(
            (node) => node.daysWithFreeTime
          );
        })
      );
  }

  loadUsersFreeTimesInDay(
    usersIds: string[],
    dateOfTimes: string
  ): Observable<FreeTime[]> {
    const GET_USERS_FREE_TIMES_IN_DAY = gql`
      query UsersFreeTimesInDay($usersIds: [UUID!]!, $dateOfTimes: Date!) {
        usersFreeTimesInDay(usersIds: $usersIds, dateOfTimes: $dateOfTimes) {
          nodes {
            id
            startTime
            endTime
          }
        }
      }
    `;

    return this.apollo
      .watchQuery<{ usersFreeTimesInDay: { nodes: FreeTime[] } }>({
        query: GET_USERS_FREE_TIMES_IN_DAY,
        variables: { usersIds, dateOfTimes },
      })
      .valueChanges.pipe(
        map((result) => result.data.usersFreeTimesInDay.nodes)
      );
  }
}
