import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { List } from './Pages/List'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<List/>}/>
      </Routes>
    </BrowserRouter>
  )
}

export default App
