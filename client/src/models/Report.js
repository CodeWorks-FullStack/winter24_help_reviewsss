import { APIItem } from "./APIItem.js";
import { Profile } from "./Profile.js";

export class Report extends APIItem {
  constructor(data) {
    super(data)
    this.title = data.title
    this.body = data.body
    this.score = data.score
    this.imgUrl = data.imgUrl
    this.restaurantId = data.restaurantId
    this.creatorId = data.creatorId
    this.creator = new Profile(data.creator)
  }
}
