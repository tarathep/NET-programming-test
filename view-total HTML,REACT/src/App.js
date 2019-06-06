import React,{Component} from 'react';
import logo from './logo.svg';
import './App.css';
import GetLocalPosts from './components/LocalPosts/GetLocalPosts';
class App extends Component {
  render() {
    return (
      <div className="App">
        <h1>OPARATOR CALL CALULATOR PRICE</h1>
        <GetLocalPosts/>
      </div>
    );
  }
}
export default App;
