import React, { Component } from 'react';
import posts from './posts.js';
//return a json file
class GetLocalPosts extends Component {
    constructor(props){
        super(props);
        this.state = {            
            posts :posts            
        };
    }
    render() {
        const {posts} = this.state;
        return(
            <div>
                <ol className="item">
                {
                    posts.map(post => (
                        <li key={post.id} align="start">
                            <div>
                                <p>Date: {post.date} Mobile: {post.mobile}</p>
                                <p>{post.price} Baht.</p>
                            </div>
                        </li>
                    ))
                }
                </ol>
            </div>
        );
    }
  }
  
  export default GetLocalPosts;