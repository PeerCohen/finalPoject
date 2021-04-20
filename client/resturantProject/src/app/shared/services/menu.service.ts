import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Menu } from '../modals/menu';
import { InventDose } from '../modals/invent-dose';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  

  subjectMenu:Subject<number>=new Subject();
  menuType="regular";
  URL: string = "http://localhost:51437/api/Menu";
  URL_INVENT="http://localhost:51437/api/InventDose";
  displayImg: boolean;

  constructor(private http: HttpClient) { }

  // getAllMenuDetails():Observable<Menu> {
  //   return this.http.get<Menu>(`${this.URL}/GetAllMenuDetails`);
  // }
  updateStatusDose(order: InventDose):Observable<any> {
    return this.http.post<InventDose>(`${this.URL_INVENT}/updateStatusDose/`,order);
  }
  getRatingByCategory(id:number):Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.URL}/GetMenuByRating/${id}`);
  }
  getMenuById(id:number):Observable<Menu> {
    return this.http.get<Menu>(`${this.URL}/GetMenuById/${id}`);
  }
  getMenuByCategory(id:number):Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.URL}/GetMenuByCategory/${id}`);
  }
  removeDose(menu:Menu):Observable<any>{ 
    return this.http.post<any>(`${this.URL}/DeleteDoseOfMenu/`,menu);
  }
  updateDose(menu:Menu):Observable<any>{ 
    return this.http.post<any>(`${this.URL}/UpdateDoseOfMenu/`,menu);
  }
  addDose(menu:Menu):Observable<any>{
    return this.http.post<any>(`${this.URL}/AddDoseOfMenu/`,menu);
  }
  getANewMenu():Observable<Array<Menu>>
  {
    return this.http.get<Array<Menu>>(`${this.URL}/GetANewMenu`);
  }
  
  getPopularBishes():Observable<Array<Menu>>
  {
    return this.http.get<Array<Menu>>(`${this.URL}/GetFavoriteMenu`);
  }
  // getMenuNewByCategory(id:number):Observable<Menu[]> {
  //   return this.http.get<Menu[]>(`${this.URL}/GetMenuNewByCategory/${id}`);
  // }
  getMenuFavoriteByCategory(id:number):Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.URL}/GetMenuFavoriteByCategory/${id}`);
  }
}