import { useSelector } from 'react-redux';
import { CartList, SectionTitle, CartTotals } from '../components';
import { Link } from 'react-router-dom';

const Cart = () => {
  const user = useSelector((state) => state.userState.user)
  const numItemsInCart = useSelector((state) => state.cartState.numItemsInCart)
  if (numItemsInCart === 0) {
    return <SectionTitle text='Cart is empty' />
  }
  return <>
    <SectionTitle text='Shopping Cart' />
    <div className="mt-8 grid gap-8 lg:grid-cols-12">
      <div className="lg:col-span-8">
        <CartList />
      </div>
      <div className="lg:col-span-4 lg:pl-4">
        <CartTotals />
        {user ? <Link to='/checkout' className='btn btn-primary btn-block mt-8'>
          Proceed to checkout
        </Link> 
        :
        <Link to='/login' className='btn btn-primary btn-block mt-8'>
          Please login
        </Link> 
        }
      </div>
    </div>
  </>
    
  
}

export default Cart