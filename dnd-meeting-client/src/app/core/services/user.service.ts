import { catchError, map, Observable, throwError } from 'rxjs';
import { User } from '../models/user.model';
import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { NotificationService } from './notification.service';

@Injectable()
export class UserService {
  constructor(private readonly apollo: Apollo,
              private readonly notify: NotificationService
  ) {}

  loadUsers(): Observable<User[]> {
    const GET_USERS = gql`
      query GetUsers {
        users {
          nodes {
            id
            name
          }
        }
      }
    `;

    return this.apollo
      .watchQuery<{ users: { nodes: User[] } }>({
        query: GET_USERS,
      })
      .valueChanges.pipe(
        map((result) => result.data.users.nodes),
        catchError(err => {
          this.notify.showError('Ошибка при получении пользователей: ' + err.message);
          return throwError(() => err);
        })
    );
  }

  getUserById(id: string): Observable<User> {
    const GET_USER_BY_ID = gql`
      query GetUserById($id: ID!) {
        node(id: $id) {
          ... on User {
            id
            name
          }
        }
      }
    `;

    return this.apollo
      .query<{ node: User }>({
        query: GET_USER_BY_ID,
        variables: { id },
      })
      .pipe(
        map((result) => result.data.node),
        catchError(err => {
          this.notify.showError('Ошибка при получении пользователя: ' + err.message);
          return throwError(() => err);
        })
    );
  }

  addUser(name: string): Observable<User> {
    const ADD_USER = gql`
      mutation AddUser($userInput: UserInput!) {
        addUser(userInput: $userInput) {
          id
          name
        }
      }
    `;

    return this.apollo
      .mutate<{ addUser: User }>({
        mutation: ADD_USER,
        variables: { userInput: { name } },
      })
      .pipe(
        map((result) => result.data!.addUser),
        catchError(err => {
          this.notify.showError('Ошибка при добавлении пользователя: ' + err.message);
          return throwError(() => err);
        })
      );
  }
}
