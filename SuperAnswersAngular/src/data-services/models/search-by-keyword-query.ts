/* tslint:disable */
import { QueryOfSearchByKeywordResponse } from './query-of-search-by-keyword-response';
export interface SearchByKeywordQuery extends QueryOfSearchByKeywordResponse {
  searchTerms?: string;
  userId?: string;
}
